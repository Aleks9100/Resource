using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ResourceDatabase;
using ResourceTable.Table;

namespace Access_Resource
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
       
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TB_Password.Text = PB_Password.Password;
            TB_Password.Visibility = Visibility.Visible;
            PB_Password.Visibility = Visibility.Hidden;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PB_Password.Password = TB_Password.Text;
            TB_Password.Visibility = Visibility.Hidden;
            PB_Password.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                int id = db.Authorization(TB_Login.Text, PB_Password.Password);
                if (id != -1)
                {
                    (new MainWindow(id)).Show();
                }
                else MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
