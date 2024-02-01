using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using ProgressTest1.Models;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace ProgressTest1
{
    public class IntToSupplierName : IValueConverter
    {
        MedicineContext context = new MedicineContext();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int supplierId)
            {
                var tmp = context.Suppliers.Where(s => s.SupplierId == supplierId).FirstOrDefault();
                return tmp.SupplierName;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class IntToGroupName : IValueConverter
    {
        MedicineContext context = new MedicineContext();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int groupId)
            {
                var tmp = context.GroupMedicines.Where(g => g.GroupId == groupId).FirstOrDefault();
                return tmp.GroupName;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MedicineContext _context;
        public MainWindow()
        {
            _context = new MedicineContext();
            InitializeComponent();
            LoadData();
        }

      

        public void LoadData()
        {
            dgMedicine.ItemsSource = _context.Medicines.ToList();
            cboGroup.ItemsSource = _context.GroupMedicines.ToList();
            cboSupplier.ItemsSource = _context.Suppliers.ToList();
        }
        private void btnRefesh_Click(object sender, RoutedEventArgs e)
        {
            txtAmount.Text = string.Empty;
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPreserve.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtUserManual.Text = string.Empty;
            dtExpiredDate.SelectedDate = null;
            cboGroup.SelectedItem = null;
            cboSupplier.SelectedItem = null;
            LoadData();
        }

        public Medicine getInfor()
        {
            try
            {
                Medicine medicine = new Medicine
                {
                    MedicineId = txtId.Text,
                    GroupId = int.Parse(cboGroup.SelectedValue.ToString()),
                    SupplierId = int.Parse(cboSupplier.SelectedValue.ToString()),
                    MedicineName = txtName.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Amount = double.Parse(txtAmount.Text),
                    ExpiriDate = dtExpiredDate.SelectedDate,
                    Preserve = txtPreserve.Text,
                    UserManual = txtUserManual.Text
                };

                return medicine;
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var medicine = getInfor();
                if(medicine != null)
                {
                    _context.ChangeTracker.Clear();
                    _context.Medicines.Add(medicine);
                    _context.SaveChanges();
                    LoadData();
                    MessageBox.Show("Insert Medicine completed", "Create Medicine");
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Insert Medicine Failed: Medicine ID is already existed", "Create Medicine");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var medicine = getInfor();
                if (medicine != null)
                {
                    var oldInfor = _context.Medicines.FirstOrDefault(c => c.MedicineId== medicine.MedicineId);
                    if(oldInfor != null)
                    {
                        oldInfor.GroupId = medicine.GroupId;
                        oldInfor.SupplierId = medicine.SupplierId;
                        oldInfor.MedicineName = medicine.MedicineName;
                        oldInfor.Price = medicine.Price;
                        oldInfor.Amount = medicine.Amount;
                        oldInfor.ExpiriDate= medicine.ExpiriDate;
                        oldInfor.Preserve= medicine.Preserve;
                        oldInfor.UserManual = medicine.UserManual;
                        _context.Update(oldInfor);
                        _context.SaveChanges();
                        LoadData();
                        MessageBox.Show("Update Medicine completed", "Update Medicine");
                    }
                    else
                    {
                        MessageBox.Show("Medicine is not exist");
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Medicine Failed: " + ex.Message, "Update Medicine");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var medicine = getInfor();
                if (medicine != null)
                {
                    var oldInfor = _context.Medicines.FirstOrDefault(c => c.MedicineId == medicine.MedicineId);
                    if (oldInfor != null)
                    {
                        _context.Remove(oldInfor);
                        _context.SaveChanges();
                        LoadData();
                        MessageBox.Show("Delete Medicine completed", "Delete Medicine");
                    }
                    else
                    {
                        MessageBox.Show("Medicine is not exist");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Medicine Failed: " + ex.Message, "Delete Medicine");
            }
        }

        private void btnXml_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    XDocument xmlDoc = XDocument.Load(openFileDialog.FileName);
                    foreach (var xe in xmlDoc.Descendants("Medicine"))
                    {
                        var medicineId = xe.Attribute("MedicineId")?.Value;
                        var medicine = _context.Medicines.FirstOrDefault(m => m.MedicineId == medicineId);
                        if (medicine == null)
                        {
                            medicine = new Medicine()
                            {
                                MedicineId = medicineId,
                                GroupId = int.Parse(xe.Element("GroupId")?.Value ?? "0"),
                                SupplierId = int.Parse(xe.Element("SupplierId")?.Value ?? "0"),
                                MedicineName = xe.Element("MedicineName")?.Value,
                                Price = decimal.Parse(xe.Element("Price")?.Value ?? "0"),
                                Amount = double.Parse(xe.Element("Amount")?.Value ?? "0"),
                                ExpiriDate = DateTime.Parse(xe.Element("ExpiriDate")?.Value ?? DateTime.Now.ToString()),
                                Preserve = xe.Element("Preserve")?.Value,
                                UserManual = xe.Element("UserManual")?.Value

                            };
                            _context.Medicines.Add(medicine);
                        }
                        else
                        {
                            medicine.GroupId = int.Parse(xe.Element("GroupId")?.Value ?? "0");
                            medicine.SupplierId = int.Parse(xe.Element("SupplierId")?.Value ?? "0");
                            medicine.MedicineName = xe.Element("MedicineName")?.Value;
                            medicine.Price = decimal.Parse(xe.Element("Price")?.Value ?? "0");
                            medicine.Amount = double.Parse(xe.Element("Amount")?.Value ?? "0");
                            medicine.ExpiriDate = DateTime.Parse(xe.Element("ExpiriDate")?.Value ?? DateTime.Now.ToString());
                            medicine.Preserve = xe.Element("Preserve")?.Value;
                            medicine.UserManual = xe.Element("UserManual")?.Value;

                        }
                        _context.SaveChanges();
                    }
                    MessageBox.Show("Load XML SuccessFully");
                    LoadData();
                }catch (Exception ex)
                {
                    MessageBox.Show("Load XML Failed: "+ex.Message);
                }
             

            }
        }

        private void btnJson_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string jsonContent = File.ReadAllText(openFileDialog.FileName);
                    var data = JsonSerializer.Deserialize<MedicineListWrapper>(jsonContent);
                    List<Medicine> medicines = data.Medicines;
                    List<int> groupIds = medicines.Select(m => m.GroupId).ToList();
                    dgMedicine.ItemsSource = _context.Medicines.Where(m => groupIds.Contains(m.GroupId)).ToList();
                    MessageBox.Show("Load JSON SuccessFully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Load JSON Failed: " + ex.Message);

                }

            }
        }
        public class MedicineListWrapper
        {
            public List<Medicine> Medicines { get; set; }
        }

        private void btnExpridate_Click(object sender, RoutedEventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime thirtyDaysFromNow = today.AddDays(30);

            dgMedicine.ItemsSource = _context.Medicines
                .Where(m => m.ExpiriDate >= today & m.ExpiriDate<=thirtyDaysFromNow)
                .ToList();
        }

        private void DgMedicine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMedicine.SelectedItem != null)
            {
                Medicine selectedMedicine =(Medicine)dgMedicine.SelectedItem;

                txtId.Text = selectedMedicine.MedicineId.ToString();
                txtName.Text = selectedMedicine.MedicineName.ToString();
                txtPrice.Text = selectedMedicine.Price.ToString();
                txtAmount.Text = selectedMedicine.Amount.ToString();
                dtExpiredDate.SelectedDate = selectedMedicine.ExpiriDate;
                txtPreserve.Text = selectedMedicine.Preserve.ToString();
                txtUserManual.Text = selectedMedicine.UserManual.ToString();
                cboGroup.SelectedValue = selectedMedicine.GroupId;
                cboSupplier.SelectedValue = selectedMedicine.SupplierId;
            }
        }
    }
}