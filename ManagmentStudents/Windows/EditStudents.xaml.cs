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
    /// Логика взаимодействия для EditStudents.xaml
    /// </summary>
    public partial class EditStudents : Window
    {
        public static Students students1 = new Students();
        public EditStudents(Students students)
        {
            InitializeComponent();
            students1 = students;
            SurNameTb.Text = students1.SurName;
            NameTb.Text = students1.Name;
            LastNameTb.Text = students1.LastName;
            DateBirthDp.SelectedDate = students1.DateBirth;
            PhoneTb.Text = students1.Phone;
            this.DataContext = this;
        }
        private void SaveEditBtn_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult message = MessageBox.Show($"Вы действительно хотите изменить студента {students1.SurName} {students1.Name} ?", "Удаление", MessageBoxButton.YesNo);
            if (message == MessageBoxResult.Yes)
            {
                students1.SurName = SurNameTb.Text;
                students1.Name = NameTb.Text;
                students1.LastName = LastNameTb.Text;
                students1.DateBirth = DateBirthDp.SelectedDate;
                students1.Phone = PhoneTb.Text;
                Connection.stusentEntities.SaveChanges();
                Studenti studentsListWindow = new Studenti();
                studentsListWindow.StudentsLv.ItemsSource = new List<Students>(Connect.Connection.stusentEntities.Students.ToList());
            }
            MessageBox.Show("Студент успешно изменен");
            Close();

        }
    }
}
