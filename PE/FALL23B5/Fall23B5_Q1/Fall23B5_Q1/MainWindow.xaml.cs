using Microsoft.Win32;
using System.IO;
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

namespace Fall23B5_Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public List<Product> Products = new List<Product>();
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = new Product()
                {
                    Id = int.Parse(tbId.Text),
                    Name = tbName.Text,
                    Price = int.Parse(tbPrice.Text)
                };
                Products.Add(product);
                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = Products;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var datas = lvProduct.ItemsSource as List<Product>;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON Files (*.json)|*.json";
                saveFileDialog.DefaultExt = ".json";
                if (saveFileDialog.ShowDialog() == true)
                {
                    string contents = JsonSerializer.Serialize(datas);
                    File.WriteAllText(saveFileDialog.FileName, contents);
                    MessageBox.Show("da save vao file: " + saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}