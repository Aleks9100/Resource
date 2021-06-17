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

namespace Access_Resource
{
    /// <summary>
    /// Логика взаимодействия для PeopleWindow.xaml
    /// </summary>
    public partial class PeopleWindow : Window
    {
        int ID = 0;
        public PeopleWindow(int id)
        {
            InitializeComponent();
            Update();
            ID = id; 
            using (var db = new ResourceModel())
            {
                if (!db.StatusAdmin(id))
                {
                    AdminPanelPeople.Visibility = Visibility.Hidden;
                    Account.Visibility = Visibility.Hidden;
                    Operator.Visibility = Visibility.Hidden;
                }
            }
        }

        public void Update()
        {
            DGR.ItemsSource = null;
            CB_Department.ItemsSource = null;
            CB_Organization.ItemsSource = null;
            CB_Position.ItemsSource = null;
            
            using (var db = new ResourceModel())
            {
                DGR.ItemsSource = db.GetPeople();
                CB_Department.ItemsSource = db.GetDepartment();
                CB_Organization.ItemsSource = db.GetOrganization();
                CB_Position.ItemsSource = db.GetPosition();
            }
        }

        private void AddPeople_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.AddPeople(TB_FirstName.Text,
                    TB_LastName.Text,
                    TB_MiddleName.Text,
                    TB_Phone.Text,
                    TB_PhoneVoIP.Text,
                    db.ConvertorObjectInInt(CB_Department.SelectedValue),
                    db.ConvertorObjectInInt(CB_Organization.SelectedValue),
                    db.ConvertorObjectInInt(CB_Position.SelectedValue)));
            }
            Update();
        }
        private void EditPeople_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.EditPeople(db.ConvertorObjectInInt(DGR.SelectedValue),
                    TB_FirstName.Text,
                    TB_LastName.Text,
                    TB_MiddleName.Text,
                    TB_Phone.Text,
                    TB_PhoneVoIP.Text,
                    db.ConvertorObjectInInt(CB_Department.SelectedValue),
                    db.ConvertorObjectInInt(CB_Organization.SelectedValue),
                    db.ConvertorObjectInInt(CB_Position.SelectedValue)));
            }
            Update();
        }
        private void SearchPeople_Click(object sender, RoutedEventArgs e)
        {
            DGR.ItemsSource = null;
           
            using (var db = new ResourceModel())
            {
                DGR.ItemsSource = db.SeacrhPeople(TB_FirstName.Text,TB_LastName.Text,TB_MiddleName.Text,TB_PhoneVoIP.Text,
                    db.ConvertorObjectInInt(CB_Department.SelectedValue),
                    db.ConvertorObjectInInt(CB_Organization.SelectedValue),
                    db.ConvertorObjectInInt(CB_Position.SelectedValue));                
            }
        }
        private void People_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void RemovePeople_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.RemovePeople(Convert.ToInt32(DGR.SelectedValue)));
            }
            Update();
        }
        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            (new OperatorWindow(ID)).Show();
            this.Close();
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

        private void Organization_Click(object sender, RoutedEventArgs e)
        {
            (new OrganizationWindow(ID)).Show();
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
    }
}
