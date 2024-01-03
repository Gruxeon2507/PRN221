using System.Globalization;
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
using WPFFormGenModel.Models;
namespace WPFFormGenModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class BooleanToGenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isMale)
            {
                return isMale ? "Male" : "Female";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class intToName : IValueConverter
    {
        UniversityDBContext db = new UniversityDBContext();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int MajorId)
            {
                var tmp = db.Majors.Where(x => x.Id == MajorId).FirstOrDefault();
                return tmp.Name;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    public partial class MainWindow : Window
    {
        private readonly UniversityDBContext _context;

        public MainWindow()
        {
            _context = new UniversityDBContext();
            InitializeComponent();
            Load_data();
        }

        private void Load_data()
        {
            ListView.ItemsSource=_context.Students.ToList();
            cboMajor.ItemsSource=_context.Majors.ToList();
        }

        private void Load_Data(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Data(object sender, RoutedEventArgs e)
        {

        }

        private void Update_Data(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Data(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Student_Up(object sender, MouseButtonEventArgs e)
        {

        }
    }
}