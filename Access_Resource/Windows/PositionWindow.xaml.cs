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
    /// Логика взаимодействия для PositionWindow.xaml
    /// </summary>
    public partial class PositionWindow : Window
    {
        int ID = 0;
        public PositionWindow(int id)
        {
            InitializeComponent();
            Update();
            ID = id;
            using (var db = new ResourceModel())
            {
                if (!db.StatusAdmin(id))
                {
                    AdminPanelPosition.Visibility = Visibility.Hidden;
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
                DGR.ItemsSource = db.GetPosition();
            }
        }

        private void AddPosition_Click(object sender, RoutedEventArgs e)
        {

            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.AddPosition(TB_Title.Text));
            }
            Update();
        }

        private void EditPosition_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.EditPosition(db.ConvertorObjectInInt(DGR.SelectedValue), TB_Title.Text));
            }
            Update();
        }

        private void RemovePosition_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.RemovePosition(Convert.ToInt32(DGR.SelectedValue)));
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

        private void SeacrhPosition_Click(object sender, RoutedEventArgs e)
        {
            DGR.ItemsSource = null;
            using (var db = new ResourceModel())
            {
                DGR.ItemsSource = db.SearchPosition(TB_Title.Text);
            }
        }

        private void Position_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
