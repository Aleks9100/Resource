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
    /// Логика взаимодействия для OperatorWindow.xaml
    /// </summary>
    public partial class OperatorWindow : Window
    {
        int ID = 0;
        public OperatorWindow(int id)
        {
            InitializeComponent();
            ID = id;
            using (var db = new ResourceModel())
            {
                if (!db.StatusAdmin(id))
                {
                    AdminPanelOperator.Visibility = Visibility.Hidden;
                    Account.Visibility = Visibility.Hidden;

                }
            }
            Update(); 
        }
        private void Update()
        {
            List<OperatorModel> models = new List<OperatorModel>();
            DGR.ItemsSource = null;
            CB_People.ItemsSource = null;
            CB_Status.ItemsSource = null;
            CB_Status.Items.Add("admin");
            CB_Status.Items.Add("user");
            using (var db = new ResourceModel())
            {
                foreach (var op in db.GetOperator())
                {
                    if (op.UserStatus != "user")
                        models.Add(new OperatorModel()
                        {
                            OperatorID = op.OperatorID,
                            Login = op.Login,
                            Password = op.Password,
                            People = op.People,
                            PeopleID = op.PeopleID,
                            UserStatus = op.UserStatus.Remove(op.UserStatus.Length - 1)
                        });
                    else models.Add(new OperatorModel()
                        {
                            OperatorID = op.OperatorID,
                            Login = op.Login,
                            Password = op.Password,
                            People = op.People,
                            PeopleID = op.PeopleID,
                            UserStatus = op.UserStatus
                        });
                }
                DGR.ItemsSource =models;
                CB_People.ItemsSource = db.GetPeople();
            }
        }
        private void AddOperator_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.AddOperator(TB_Login.Text,
                    TB_Password.Text,
                    db.ConvertorObjectInInt(CB_People.SelectedValue),
                   Convert.ToString(CB_Status.SelectedItem)));
            }
            Update();
        }

        //private void EditOperator_Click(object sender, RoutedEventArgs e)
        //{
        //    using (var db = new ResourceModel())
        //    {
        //        MessageBox.Show(db.EditOperator(db.ConvertorObjectInInt(DGR.SelectedValue),
        //            TB_Login.Text,
        //            TB_Password.Text,
        //            db.ConvertorObjectInInt(CB_People.SelectedValue),
        //           Convert.ToString(CB_Status.SelectedItem)));
        //    }
        //    Update();
        //}

        private void RemoveOperator_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.RemoveOperator(Convert.ToInt32(DGR.SelectedValue)));
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

        private void SearchOperator_Click(object sender, RoutedEventArgs e)
        {
            List<OperatorModel> models = new List<OperatorModel>();
            using (var db = new ResourceModel())
            {
                foreach (var op in db.SearchOperator(TB_Login.Text, CB_Status.Text))
                {
                    if (op.UserStatus != "user")
                        models.Add(new OperatorModel()
                        {
                            OperatorID = op.OperatorID,
                            Login = op.Login,
                            Password = op.Password,
                            People = op.People,
                            PeopleID = op.PeopleID,
                            UserStatus = op.UserStatus.Remove(op.UserStatus.Length - 1)
                        });
                    else models.Add(new OperatorModel()
                    {
                        OperatorID = op.OperatorID,
                        Login = op.Login,
                        Password = op.Password,
                        People = op.People,
                        PeopleID = op.PeopleID,
                        UserStatus = op.UserStatus
                    });
                }
                DGR.ItemsSource = models;
                CB_People.ItemsSource = db.GetPeople();
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
