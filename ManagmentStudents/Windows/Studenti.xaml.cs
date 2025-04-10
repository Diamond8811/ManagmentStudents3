using ManagmentStudents.Connect;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ManagmentStudents.Windows
{
    /// <summary>
    /// Логика взаимодействия для Studenti.xaml
    /// </summary>
    public partial class Studenti : Window
    {
        public static List<Students> students { get; set; }
        public Studenti()
        {
            InitializeComponent();
            students = new List<Students>(Connect.Connection.stusentEntities.Students.ToList());
            this.DataContext = this;
        }
        private void SearchStudent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var phone = SearchStudent.Text;
            if (phone == "")
                StudentsLv.ItemsSource = new List<Students>(Connect.Connection.stusentEntities.Students.ToList());
            else
                StudentsLv.ItemsSource = new List<Students> (Connection.stusentEntities.Students.Where(i => i.Phone == phone).ToList());
        }

        private void EditStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            var students = StudentsLv.SelectedItem as Students;
            if (students != null)
            {
                Windows.EditStudents editReaderWindow = new Windows.EditStudents(students);
                editReaderWindow.Show();

            }
            else
            {
                MessageBox.Show("Для редактирования выберите студента");
            }
        }

        private void DeleteStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsLv.SelectedItem != null)
            {

                students.Remove((Students)StudentsLv.SelectedItem);


                StudentsLv.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Выберите студента для удаления!");
            }

        }

        private void AddStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddStudents addStudents = new Windows.AddStudents();
            addStudents.Show();
        }
    }
}
