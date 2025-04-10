using ManagmentStudents.Connect;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddStudents.xaml
    /// </summary>
    public partial class AddStudents : Window
    {
        public static Students student = new Students();
        public AddStudents()
        {
            InitializeComponent();
        }
        private void SaveReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            Students students = new Students();
            students.SurName = SurNameTb.Text.Trim();
            students.Name = NameTb.Text.Trim();
            students.LastName = LastNameTb.Text.Trim();
            students.DateBirth = BirthDateDp.SelectedDate;
            students.Phone = PhoneTb.Text.Trim();
            Connection.stusentEntities.Students.Add(students);
            Connection.stusentEntities.SaveChanges();
            MessageBox.Show("Читатель успешно добавлен.");
            Close();
        }
    }
}
