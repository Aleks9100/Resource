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
using Access_Resource.AddEditWindows;
using ResourceDatabase;

namespace Access_Resource
{
    /// <summary>
    /// Логика взаимодействия для DepartmentWindow.xaml
    /// </summary>
    public partial class DepartmentWindow : Window
    {
        public DepartmentWindow()
        {
            InitializeComponent();
            using (var db = new ResourceModel())
            {
                DGR.ItemsSource = db.GetDepartment(); 
            }
        }
            private void Button_Click(object sender, RoutedEventArgs e)
        {
            (new AddEditDepartment(this)).Show();
            IsEnabled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            (new AddEditDepartment(this,Convert.ToInt32(DGR.SelectedValue))).Show();
            IsEnabled = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                    MessageBox.Show(db.RemoveDepartmentOrOrganization(Convert.ToInt32(DGR.SelectedValue), "Department"));
            }
        }
    }
}
