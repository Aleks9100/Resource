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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Access_Resource
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int ID = 0;
        public MainWindow()
        {
            InitializeComponent();
            Update();
        }
        public MainWindow(int id)
        {
            InitializeComponent();
            Update();
            ID = id;
            using (var db = new ResourceModel()) 
            {
                if (!db.StatusAdmin(id)) 
                {
                    AdminPanelComputer.Visibility = Visibility.Hidden;
                    Account.Visibility = Visibility.Hidden;
                    Operator.Visibility = Visibility.Hidden;
                }
            }
        }
        public void Update()
        {
            DGR.ItemsSource = null;
            CB_WorkingGroup.ItemsSource = null;
            CB_People.ItemsSource = null;
            using (var db = new ResourceModel())
            {
                DGR.ItemsSource = db.GetComputer();
                CB_WorkingGroup.ItemsSource = db.GetWorking_Group();
                CB_People.ItemsSource = db.GetPeople();
            }
        }

        private void RemoveComputer_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.RemoveComputer(db.ConvertorObjectInInt(DGR.SelectedValue)));
                Update();
            }
        }

        private void AddComputer_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel()) 
            {
                MessageBox.Show(db.AddComputer(TB_Indificator.Text,
                    TB_IP.Text,
                    TB_Description.Text,
                    TB_Name.Text,TB_Domen.Text,
                    db.ConvertorObjectInInt(CB_WorkingGroup.SelectedValue),
                    db.ConvertorObjectInInt(CB_People.SelectedValue)));
                Update();
            }
        }

        private void EditComputer_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.EditComputer(db.ConvertorObjectInInt(DGR.SelectedValue),TB_Indificator.Text,
                    TB_IP.Text,
                    TB_Description.Text,
                    TB_Name.Text, TB_Domen.Text,
                    db.ConvertorObjectInInt(CB_WorkingGroup.SelectedValue),
                    db.ConvertorObjectInInt(CB_People.SelectedValue)));
                Update();
            }
        }

        private void Deparatament_Click(object sender, RoutedEventArgs e)
        {
            (new DepartmentWindow(ID)).Show();
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
    }
}
