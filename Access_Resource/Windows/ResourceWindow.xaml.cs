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
    /// Логика взаимодействия для ResourceWindow.xaml
    /// </summary>
    public partial class ResourceWindow : Window
    {
        int ID = 0;
        public ResourceWindow(int id)
        {
            InitializeComponent();
            Update();
            ID = id;
            using (var db = new ResourceModel())
            {
                if (!db.StatusAdmin(id))
                {
                    AdminPanelResource.Visibility = Visibility.Hidden;
                    Account.Visibility = Visibility.Hidden;
                    Operator.Visibility = Visibility.Hidden;
                }
            }
        }

        public void Update()
        {
            DGR.ItemsSource = null;
            CB_People.ItemsSource = null;
            using (var db = new ResourceModel())
            {
                DGR.ItemsSource = db.GetResource();
                CB_People.ItemsSource = db.GetPeople();
            }
        }

        private void AddResource_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.AddResource(TB_Title.Text,
                    Convert.ToDateTime(DT_DateStart.SelectedDate),
                    Convert.ToDateTime(DT_DateEnd.SelectedDate),
                    db.ConvertorObjectInInt(CB_People.SelectedValue)));
            }
            Update();
        }

        private void EditResource_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.EditResource(db.ConvertorObjectInInt(DGR.SelectedValue),
                    TB_Title.Text,
                    Convert.ToDateTime(DT_DateStart.SelectedDate),
                    Convert.ToDateTime(DT_DateEnd.SelectedDate),
                    db.ConvertorObjectInInt(CB_People.SelectedValue)));
            }
            Update();
        }

        private void RemoveResource_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.RemoveResource(db.ConvertorObjectInInt(DGR.SelectedValue)));
            }
            Update();
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
