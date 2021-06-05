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
        public PeopleWindow()
        {
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            DGR.ItemsSource = null;
            using (var db = new ResourceModel())
            {
                DGR.ItemsSource = db.GetPeople();
            }
        }

        private void AddPeople_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditPeople_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemovePeople_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
