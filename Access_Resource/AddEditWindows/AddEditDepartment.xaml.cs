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
    /// Логика взаимодействия для AddEditDepartment.xaml
    /// </summary>
    public partial class AddEditDepartment : Window
    {
        DepartmentWindow DepartmentWindow;
        int ID = -1;
        public AddEditDepartment(DepartmentWindow departmentWindow)
        {
            InitializeComponent();
            DepartmentWindow = departmentWindow;       
        }
        public AddEditDepartment(DepartmentWindow departmentWindow, int id)
        {
            InitializeComponent();
            DepartmentWindow = departmentWindow;
            ID = id;
            Title = "Редактирование отдела";
            AddEditButton.Content = "Редактировать отдел";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                if (ID == -1)
                {
                    MessageBox.Show(db.AddDepartmentOrOrganization(TB_Title.Text, "Department"));
                    DepartmentWindow.IsEnabled = true;
                    Close();
                }
                else
                {
                    MessageBox.Show(db.EditDepartmentOrOrganization(ID,TB_Title.Text, "Department"));
                    DepartmentWindow.IsEnabled = true;
                    Close();
                }
            }
        }
    }
}
