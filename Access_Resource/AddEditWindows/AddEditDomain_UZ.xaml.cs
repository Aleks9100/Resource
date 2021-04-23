using ResourceDatabase;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Access_Resource.AddEditWindows
{
    /// <summary>
    /// Логика взаимодействия для AddEditDomain_UZ.xaml
    /// </summary>
    public partial class AddEditDomain_UZ : Window
    {
        MainWindow MainWindow;
        int ID = -1;
        public AddEditDomain_UZ(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;       
        }
        public AddEditDomain_UZ(MainWindow mainWindow, int id)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            ID = id;
            using (var db = new ResourceModel())
            {
                var item = db.GetDomain_UZInId(ID);
                TB_Login.Text = item.Login;
                PB_Password.Text = item.Password;
                TB_Status.Text = item.Status;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //using (var db = new ResourceModel())
            //{
            //    if (ID == -1)
            //    {
            //        MessageBox.Show(db.AddAccount(TB_Login.Text, PB_Password.Text, "Domain", TB_Status.Text));
            //        MainWindow.IsEnabled = true;
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show(db.EditAccount(ID, TB_Login.Text, PB_Password.Text, "Domain",TB_Status.Text));
            //        MainWindow.IsEnabled = true;
            //        this.Close();
            //    }
            //}
        }
    }
}
