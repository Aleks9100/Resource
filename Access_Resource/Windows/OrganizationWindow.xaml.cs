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
        int ID = 0;
        public OrganizationWindow(int id)
        {
            InitializeComponent();
            Update();
            ID = id;
            using (var db = new ResourceModel())
            {
                if (!db.StatusAdmin(id))
                {
                    AdminPanelOrganization.Visibility = Visibility.Hidden;
                    Account.Visibility = Visibility.Hidden;
                    Operator.Visibility = Visibility.Hidden;
                }
            }
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
                Update();
            }
        }

        private void AddOrganization_Click(object sender, RoutedEventArgs e)
        {
            using (var Db = new ResourceModel())
            {
                MessageBox.Show(Db.AddDepartmentOrOrganization(TB_Title.Text, "Organization"));
                Update();
            }
        }

        private void EditOrganization_Click(object sender, RoutedEventArgs e)
        {
            using (var Db = new ResourceModel())
            {
                MessageBox.Show(Db.EditDepartmentOrOrganization(Db.ConvertorObjectInInt(DGR.SelectedValue), TB_Title.Text, "Organization"));
                Update();
            }
        }
        private void Deparatament_Click(object sender, RoutedEventArgs e)
        {
            (new DepartmentWindow(ID)).Show();
            this.Close();
        }

        private void Computer_Click(object sender, RoutedEventArgs e)
        {
            (new MainWindow(ID)).Show();
            this.Close();
        }
        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            (new OperatorWindow(ID)).Show();
            this.Close();
        }

        private void People_Click(object sender, RoutedEventArgs e)
        {
            (new PeopleWindow(ID)).Show();
            this.Close();
        }

        private void Position__Click(object sender, RoutedEventArgs e)
        {
            (new PositionWindow(ID)).Show();
            this.Close();
        }

        private void Resource__Click(object sender, RoutedEventArgs e)
        {
            (new ResourceWindow(ID)).Show();
            this.Close();
        }

        private void WG__Click(object sender, RoutedEventArgs e)
        {
            (new Working_GroupWindow(ID)).Show();
            this.Close();
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            (new AccountWindow(ID)).Show();
            this.Close();
        }

        private void SearchOrganization_Click(object sender, RoutedEventArgs e)
        {
            DGR.ItemsSource = null;
            using (var db = new ResourceModel())
            {
                DGR.ItemsSource = db.SearchOrganization(TB_Title.Text);
            }
        }

        private void Organization_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
