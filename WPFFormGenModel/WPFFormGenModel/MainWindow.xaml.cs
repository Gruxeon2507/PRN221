using System.Globalization;
using System.Reflection;
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
using System.Xml.Linq;
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

        public Student GetInfor()
        {
            try
            {
                bool gender = true;
                Major major = (Major)cboMajor.SelectedItem;
                if (rdoFemale.IsChecked == true)
                {
                    gender = false;
                }

                Student student = new Student
                {
                    
                    Name = txtName.Text,
                    Dob = dtDob.SelectedDate,
                    Gender = gender,
                    Phone = txtPhone.Text,
                    Major = major.Id,
                };
                if (txtId.Text != null)
                {
                    student.Id = int.Parse(txtId.Text);
                }
                return student;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        private void Load_Data(object sender, RoutedEventArgs e)
        {
           Load_data();
        }

        private void Add_Data(object sender, RoutedEventArgs e)
        {
            try
            {
                var student = GetInfor();
                if (student != null)
                {
                    _context.Students.Add(student);
                    _context.SaveChanges();
                    Load_data();
                    MessageBox.Show("Insert Student completed", "Create Student");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Student Wrong" + ex.Message, "Create Student");
            }
        }

        private void Update_Data(object sender, RoutedEventArgs e)
        {
            try
            {
                var student = GetInfor();
                if (student != null)
                {
                    var oldInfor = _context.Students.FirstOrDefault(c => c.Id == student.Id);
                    if (oldInfor != null)
                    {
                        bool gender = true;
                        Major major = (Major)cboMajor.SelectedItem;
                        if (rdoFemale.IsChecked == true)
                        {
                            gender = false;
                        }
                        oldInfor.Name = txtName.Text;
                        oldInfor.Dob = dtDob.SelectedDate;
                        oldInfor.Gender = gender;
                        oldInfor.Phone = txtPhone.Text;
                        oldInfor.Major = major.Id;
                        _context.Students.Update(oldInfor);
                        _context.SaveChanges();
                        Load_data();
                        MessageBox.Show("Update Student Infor completed", "Update Infor");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Student Infor Wrong" + ex.Message, "Update Infor");
            }
        }

        private void Delete_Data(object sender, RoutedEventArgs e)
        {
            try
            {
                var student = GetInfor();
                if (student != null)
                {
                    var oldInfor = _context.Students.FirstOrDefault(c => c.Id == student.Id);
                    if (oldInfor != null)
                    {
                        _context.Students.Remove(oldInfor);
                        _context.SaveChanges();
                        Load_data();
                        MessageBox.Show("Delete Student completed", "Delete Infor");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Student Wrong" + ex.Message, "Delete Student");
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Student_Up(object sender, MouseButtonEventArgs e)
        {

        }
    }
}