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

namespace Access_Resource.AddEditWindows
{
    /// <summary>
    /// Логика взаимодействия для AddEdit1CERP.xaml
    /// </summary>
    public partial class AddEdit1CERP : Window
    {
        MainWindow MainWindow;
        string Title;
        int ID = -1;
        public AddEdit1CERP(MainWindow mainWindow,string title)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            Title = title;           
        }
        public AddEdit1CERP(MainWindow mainWindow,int id, string title)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            Title = title;
            ID = id;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
