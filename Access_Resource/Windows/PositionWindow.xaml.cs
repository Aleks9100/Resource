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
        public PositionWindow()
        {
            InitializeComponent();
            Update();
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
    }
}
