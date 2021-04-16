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
    /// Логика взаимодействия для AddEdit1CERP.xaml
    /// </summary>
    public partial class AddEdit1CERP : Window
    {
        MainWindow MainWindow;
        string Title;
        int ID = -1;
        public AddEdit1CERP(MainWindow mainWindow,string title)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            Title = title;
            if (Title == "1C_ERP")
            {
                this.Title = "Добавления 1С";
                AddEditButton.Content = "Добавить 1С";
            }
            else if (Title == "Cisco")
            {
                this.Title = "Добавления Cisco";
                AddEditButton.Content = "Добавить Cisco";
            }
            else if (Title == "Directum")
            {
                this.Title = "Добавления Directum";
                AddEditButton.Content = "Добавить Directum";
            }
            else if (Title == "Kerio")
            {
                this.Title = "Добавления Kerio";
                AddEditButton.Content = "Добавить Kerio";
            }
            else if (Title == "Mail")
            {
                this.Title = "Добавления Mail";
                AddEditButton.Content = "Добавить Mail";
            }
            else if (Title == "Truekonff")
            {
                this.Title = "Добавления Truekonff";
                AddEditButton.Content = "Добавить Truekonff";
            }
        }
        public AddEdit1CERP(MainWindow mainWindow,int id, string title)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            Title = title;
            ID = id;
            using (var db = new ResourceModel())
            {
                if (Title == "1C_ERP")
                {
                    this.Title = "Редактирование 1С";
                    AddEditButton.Content = "Редактировать 1С";
                    var item = db.Get_1C_ERPInId(ID);
                    TB_Login.Text = item.Login;
                    PB_Password.Text = item.Password;
                }
                else if (Title == "Cisco")
                {
                    this.Title = "Редактирование Cisco";
                    AddEditButton.Content = "Редактировать Cisco";
                    var item = db.GetCisco_WebexInId(ID);
                    TB_Login.Text = item.Login;
                    PB_Password.Text = item.Password;
                }
                else if (Title == "Directum")
                {
                    this.Title = "Редактирование Directum";
                    AddEditButton.Content = "Редактировать Directum";
                    var item = db.GetDirectumInId(ID);
                    TB_Login.Text = item.Login;
                    PB_Password.Text = item.Password;
                }
                else if (Title == "Kerio")
                {
                    this.Title = "Редактирование Kerio";
                    AddEditButton.Content = "Редактировать Kerio";
                    var item = db.GetKerioInId(ID);
                    TB_Login.Text = item.Login;
                    PB_Password.Text = item.Password;
                }
                else if (Title == "Mail")
                {
                    this.Title = "Редактирование Mail";
                    AddEditButton.Content = "Редактировать Mail";
                    var item = db.GetMailInId(ID);
                    TB_Login.Text = item.Login;
                    PB_Password.Text = item.Password;
                }
                else if (Title == "Truekonff")
                {
                    this.Title = "Редактирование Truekonff";
                    AddEditButton.Content = "Редактировать Truekonff";
                    var item = db.GetTruekonffInId(ID);
                    TB_Login.Text = item.Login;
                    PB_Password.Text = item.Password;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                if (ID == -1)
                {
                    MessageBox.Show(db.AddAccount(TB_Login.Text, PB_Password.Text, Title, ""));
                    MainWindow.IsEnabled = true;
                    this.Close();
                }
                else 
                {
                    MessageBox.Show(db.EditAccount(ID,TB_Login.Text, PB_Password.Text, Title, ""));
                    MainWindow.IsEnabled = true;
                    this.Close();
                }
            }
        }
    }
}
