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
    /// Логика взаимодействия для OrganizationWindow.xaml
    /// </summary>
    public partial class OrganizationWindow : Window
    {
        public OrganizationWindow()
        {
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            DGR.ItemsSource = null;
            using (var db = new ResourceModel())
            {
                DGR.ItemsSource = db.GetOrganization();
            }
        }

        private void RemoveOrganization_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.RemoveDepartmentOrOrganization(db.ConvertorObjectInInt(DGR.SelectedValue), "Organization"));
            }
        }

        private void AddOrganization_Click(object sender, RoutedEventArgs e)
        {
            using (var Db = new ResourceModel())
            {
                MessageBox.Show(Db.AddDepartmentOrOrganization(TB_Title.Text, Title));
            }
        }

        private void EditOrganization_Click(object sender, RoutedEventArgs e)
        {
            using (var Db = new ResourceModel())
            {
                MessageBox.Show(Db.EditDepartmentOrOrganization(Db.ConvertorObjectInInt(DGR.SelectedValue), TB_Title.Text, "Organization"));
            }
        }
    }
}
