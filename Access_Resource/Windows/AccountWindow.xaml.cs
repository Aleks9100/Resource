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
using Access_Resource.AddEditWindows;
using ResourceDatabase;

namespace Access_Resource
{
    /// <summary>
    /// Логика взаимодействия для AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        public AccountWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (new AddEdit1CERP(-1, this)).Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                (new AddEdit1CERP(db.ConvertorObjectInInt(DGR_Accounts.SelectedValue), this)).Show();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.RemoveAccount(db.ConvertorObjectInInt(DGR_Accounts.SelectedValue)));
            }
        }
    }
}
