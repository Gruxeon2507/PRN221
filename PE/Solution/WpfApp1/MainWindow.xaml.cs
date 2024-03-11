using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PRN221_Spr22Context _context;
        public MainWindow(PRN221_Spr22Context context)
        {
            InitializeComponent();
            _context = context;
            HandleBeforeLoaded();
        }

        public void UpdateGridView()
        {
            ListEmployee.ItemsSource = _context.Employees.ToList();
        }
        private void HandleBeforeLoaded()
        {
            UpdateGridView();
        }

        public Employee EmployeeGetEmployeeObject()
        {
            try
            {
                return new Employee
                {
                    Id = string.IsNullOrEmpty(employeeID.Text) ? 0 : int.Parse(employeeID.Text),
                    Name = employeeName.Text,
                    Gender = male.IsChecked == true ? "male" : "Female",
                    Phone = phone.Text,
                    Dob = dob.SelectedDate,
                    Idnumber = idNumber.Text
                };
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            employeeID.Text = string.Empty;
            employeeName.Text = string.Empty;
            male.IsChecked = true;
            phone.Text = string.Empty;
            dob.SelectedDate = null;
            idNumber.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = EmployeeGetEmployeeObject(); 
                if(employee != null)
                {
                    employee.Id = 0;
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    UpdateGridView();
                    MessageBox.Show("Insert employee success", "Add Employee");
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Insert employee failed", "Add Employee");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = EmployeeGetEmployeeObject();
                if (employee != null)
                {
                    var oldEmployee = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
                    if (oldEmployee != null)
                    {
                        oldEmployee.Dob = employee.Dob;
                        oldEmployee.Phone = employee.Phone;
                        oldEmployee.Name = employee.Name;
                        oldEmployee.Idnumber = employee.Idnumber;
                        oldEmployee.Gender = employee.Gender;
                        _context.Employees.Update(oldEmployee);
                        _context.SaveChanges();
                        UpdateGridView();
                        MessageBox.Show("Update employee success", "Edit Employee");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update employee failed", "Edit Employee");

            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = EmployeeGetEmployeeObject();
                if (employee != null)
                {
                    var oldEmployee = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
                    if (oldEmployee != null)
                    {
                        _context.Employees.Remove(oldEmployee);
                        _context.SaveChanges();
                        UpdateGridView();
                        MessageBox.Show("Update employee success", "Edit Employee");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert employee failed", "Add Employee");
            }
        }

        private void ListEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                var gender = ((Employee)item).Gender;
                if(!string.IsNullOrEmpty(gender))
                {
                    if (gender.ToLower() == "male")
                    {
                        male.IsChecked = true;
                        female.IsChecked = false;
                    }
                    else
                    {
                        male.IsChecked = false;
                        female.IsChecked = true;
                    }
                }
                else
                {
                    male.IsChecked = false;
                    female.IsChecked = false;
                }
            }
        }
    }
}