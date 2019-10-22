using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TutoringService
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students;        
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            students = new List<Student>();

            //StreamReader?
            using (var reader = new StreamReader("students.csv"))
            {
                string[] lines = File.ReadAllLines("students.csv");

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    Student student = Student.Parse(line);
                    students.Add(student);
                    ComboBoxStudents.Items.Add(student);
                }
            }

            foreach (var level in Service.Levels)
            {
                GroupBoxSchoolLevel.Children.Add(new RadioButton { Content = level.ToString() });
            }

            foreach (var subject in Service.Subjects)
            {
                GroupBoxSubject.Children.Add(new RadioButton { Content = subject });
            }
        }

        private void ComboBoxStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student student = ComboBoxStudents.SelectedItem as Student;
            foreach (var service in student.Services)
            {
                ListBoxTutoringService.Items.Add(service.ToString());
            }
            LabelStudentName.Content = student.ToString();
            ImageStudent.Source = new BitmapImage(new Uri(student.ImagePath, UriKind.Relative));
        }        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int level = 0;
            foreach (var lev in GroupBoxSchoolLevel.Children)
            {
                if ((lev as RadioButton).IsChecked ?? false)
                {
                    level = int.Parse((lev as RadioButton).Content.ToString());
                }
            }

            string subject = "";
            foreach (var sub in GroupBoxSubject.Children)
            {
                if ((sub as RadioButton).IsChecked ?? false)
                {
                    subject = (sub as RadioButton).Content.ToString();
                }
            }

            Service service = new Service { Level = level, Subject = subject };

            ListBoxTutoringService.Items.Add(service);            
            (ComboBoxStudents.SelectedItem as Student).Services.Add(service);
            LabelTutoringService.Content = $"{(ComboBoxStudents.SelectedItem as Student).Services.Count} Nachhilfen:";
        }

        private void Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxStudents.Items.Clear();
            }catch(NullReferenceException ex)
            {
                
            };            

            foreach (var student in students)
            {
                if((CheckBox4A.IsChecked ?? false) && (student.Clazz.Equals("4a")))
                {
                    ComboBoxStudents.Items.Add(student);
                }else if((CheckBox4B.IsChecked ?? false) && (student.Clazz.Equals("4b")))
                {
                    ComboBoxStudents.Items.Add(student);
                }
            }
        }
    }
    
}
