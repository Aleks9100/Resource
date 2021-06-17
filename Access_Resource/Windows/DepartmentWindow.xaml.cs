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
        int ID = 0;
        public DepartmentWindow(int id)
        {
            InitializeComponent();
            Update();
            ID = id;
            using (var db = new ResourceModel()) 
            {
                if (!db.StatusAdmin(id)) 
                {
                    AdminPanelDepartament.Visibility = Visibility.Hidden;
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

        private void Organization_Click(object sender, RoutedEventArgs e)
        {
            (new OrganizationWindow(ID)).Show();
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

        private void SeacrhDepartament_Click(object sender, RoutedEventArgs e)
        {
            DGR.ItemsSource = null;
            using (var db = new ResourceModel())
            {
                DGR.ItemsSource = db.SearchDepartment(TB_Title.Text);
            }
        }

        private void Departament_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
