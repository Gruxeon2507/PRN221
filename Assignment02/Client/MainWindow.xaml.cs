using Client.Models;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Assignment02Context _context = new Assignment02Context();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();

        }
        public void LoadData()
        {
            List<DTO> phones = _context.TblPhones.ToList()
               .Select(item => new DTO()
               {
                   Id = item.Id,
                   Name = item.Name,
                   DateofManufacture = item.DateofManufacture,
                   Branch = item.Branch,
                   StopManufacture = item.StopManufacture,
                   StopManufactureString = item.StopManufacture == true ? "Yes" : "No",
               }).ToList();

            lsPhone.ItemsSource = phones;
            tempPhoneList = phones;
        }

        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        public DTO GetTblPhoneObjectDTO()
        {
            try
            {
                return new DTO
                {
                    Id = string.IsNullOrEmpty(txtId.Text) ? 0 : int.Parse(txtId.Text),
                    Name = txtName.Text,
                    Branch = txtBranch.Text,
                    DateofManufacture = dpDateofManufacture.SelectedDate,
                    StopManufacture = cbStopManufacture.IsChecked == true ? true : false,
                    StopManufactureString = cbStopManufacture.IsChecked == true ? "Yes" : "No",
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot get TblPhone", "Get TblPhone");
            }
            return null;
        }
        private void btnAddToList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var phone = GetTblPhoneObjectDTO();
                tempPhoneList.Add(phone);
                lsPhone.ItemsSource = null;
                lsPhone.ItemsSource = tempPhoneList;
                MessageBox.Show("Insert success " + phone.Id + " " + phone.Name, "Add TblPhone");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert failed", "Add TblPhone");
            }
        }
        private List<DTO> tempPhoneList = new List<DTO>();

        private void btnSendToServer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var phoneInfo = tempPhoneList;
                string jsonData = JsonSerializer.Serialize(phoneInfo, new JsonSerializerOptions { WriteIndented = true });
                string host = "127.0.0.1";
                int port = 5000;
                try
                {
                    TcpClient tcpClient = new TcpClient(host, port);
                    NetworkStream stream = null;
                    Byte[] data = Encoding.ASCII.GetBytes($"{jsonData}");

                    while (true)
                    {
                        stream = tcpClient.GetStream();
                        stream.Write(data, 0, data.Length);
                        break;

                    }
                    tcpClient.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void listView_Click(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                cbStopManufacture.IsChecked = ((DTO)item).StopManufacture == true ? true : false;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lsPhone.SelectedItem != null)
            {
                var selectedPhone = (DTO)lsPhone.SelectedItem;
                tempPhoneList.Remove(selectedPhone);
                lsPhone.Items.Refresh();
            }
        }
    }
}
