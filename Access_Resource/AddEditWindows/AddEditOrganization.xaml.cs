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
using ResourceDatabase;

namespace Access_Resource.AddEditWindows
{
    /// <summary>
    /// Логика взаимодействия для AddEditOrganization.xaml
    /// </summary>
    public partial class AddEditOrganization : Window
    {
        int ID;
        MainWindow MainWindow;
        string Title="";
        public AddEditOrganization(int id,MainWindow main,string title)
        {
            InitializeComponent();
            ID = id;
            MainWindow = main;
            Title = title;
            using (var db = new ResourceModel())
            {
                if (ID != -1 && Title == "Organization")
                {
                    var organization = db.GetOrganizationInId(ID);
                    TB_Title.Text = organization.Title;
                    this.Title = "Редактирование";
                    AddEditButton.Content = "Редактировать организацию";
                }
                else if (ID != -1 && Title == "Department")
                {
                    var department = db.GetDepartmentInId(ID);
                    TB_Title.Text = department.Title;
                    this.Title = "Редактирование";
                    AddEditButton.Content = "Редактировать отдел";
                }
                else if (ID == -1 && Title == "Department") 
                {
                    AddEditButton.Content = "Добавить отдел";
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var Db = new ResourceModel())
            {
                if (ID == -1)
                {
                    MessageBox.Show(Db.AddDepartmentOrOrganization(TB_Title.Text,Title));
                }
                else MessageBox.Show(Db.EditDepartmentOrOrganization(ID,TB_Title.Text, Title));
            }
        }
    }
}
