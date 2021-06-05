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
        public MainWindow()
        {
            InitializeComponent();
            Update();
        }
        public void Update()
        {
            DGR.ItemsSource = null;
            using (var db = new ResourceModel())
            {
                DGR.ItemsSource = db.GetComputer();
            }
        }

        private void RemoveComputer_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.RemoveComputer(db.ConvertorObjectInInt(DGR.SelectedValue)));
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            (new DepartmentWindow()).Show();
            this.Close();
        }

        private void AddComputer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditComputer_Click(object sender, RoutedEventArgs e)
        {

        }       
    }
}
