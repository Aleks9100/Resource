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
            Update();
        }

        public void Update() 
        {
            DGR.ItemsSource = null;
            using (var db = new ResourceModel())
            {
                DGR.ItemsSource = db.GetDepartment();
            }
        }
        private void RemoveDepartament_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                    MessageBox.Show(db.RemoveDepartmentOrOrganization(Convert.ToInt32(DGR.SelectedValue), "Department"));
            }
            Update();
        }

        private void AddDepartament_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                    MessageBox.Show(db.AddDepartmentOrOrganization(TB_Title.Text, "Department"));
            }
            Update();
        }

        private void EditDepartament_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.EditDepartmentOrOrganization(db.ConvertorObjectInInt(DGR.SelectedValue), TB_Title.Text, "Department"));
            }
            Update();
        }
    }
}
