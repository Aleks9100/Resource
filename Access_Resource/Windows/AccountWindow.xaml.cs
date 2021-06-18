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
    /// Логика взаимодействия для AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        int ID = 0;
        public AccountWindow(int id)
        {
            InitializeComponent();
            ID = id;
            Update();
        }
        public void Update() 
        {
            List<AccountModel> accounts = new List<AccountModel>();
            DGR_Accounts.ItemsSource = null;
            using (var db = new ResourceModel()) 
            {
                var acc = db.GetAccount();
                foreach (var a in acc)
                {
                    accounts.Add(new AccountModel()
                    {
                        AccountID = a.AccountID,
                        Login = a.Login,
                        Type_Account = a.Type_Account,
                        LastNamePeople = a.LastNamePeople,
                        Passwords = db.GetPassword(ID)
                    });
                }
            }
            DGR_Accounts.ItemsSource = accounts;
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            List<AccountModel> accounts = new List<AccountModel>();
            using (var db = new ResourceModel())
            {
                var acc = db.GetAccountInId(db.ConvertorObjectInInt(DGR_Accounts.SelectedValue));
                foreach (var a in acc)
                {
                    accounts.Add(new AccountModel()
                    {
                        AccountID = a.AccountID,
                        Login = a.Login,
                        Type_Account = a.Type_Account,
                        LastNamePeople = a.LastNamePeople,
                        Passwords = db.GetPasswordD(ID)
                    });
                }
            }
            DGR_Accounts.ItemsSource = null;
            DGR_Accounts.ItemsSource = accounts;
        }
        private void SeacrAccount_Click(object sender, RoutedEventArgs e)
        {
            List<AccountModel> accounts = new List<AccountModel>();
            DGR_Accounts.ItemsSource = null;
            using (var db = new ResourceModel())
            {
                var acc = db.SearchAccount(TB_Login.Text,TB_Type.Text,CB_LN.Text);
                foreach (var a in acc)
                {
                    accounts.Add(new AccountModel()
                    {
                        AccountID = a.AccountID,
                        Login = a.Login,
                        Type_Account = a.Type_Account,
                        LastNamePeople = a.LastNamePeople,
                        Passwords = db.GetPasswordD(ID)
                    });
                }
            }
            DGR_Accounts.ItemsSource = accounts;
        }
        private void Account_Click(object sender, RoutedEventArgs e)
        {
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

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        
    }
}
