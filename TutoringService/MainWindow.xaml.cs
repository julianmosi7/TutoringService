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
            using (var reader = new StreamReader("subjects.csv"))
            {
                string line = reader.ReadToEnd();
                string[] parts = line.Split(';');
                foreach (string part in parts)
                {
                    Console.WriteLine(part);
                    Student.Parse(part);                    
                }                       
            }

            using (var reader = new StreamReader("students.csv"))
            {
                string[] lines = File.ReadAllLines("students.csv");
                
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    Console.WriteLine(line);
                    Student.Parse(line);                   
                }
            }
        }
    }
}
