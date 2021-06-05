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
    /// Логика взаимодействия для Working_GroupWindow.xaml
    /// </summary>
    public partial class Working_GroupWindow : Window
    {
        public Working_GroupWindow()
        {
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            DGR.ItemsSource = null;
            using (var db = new ResourceModel())
            {
                DGR.ItemsSource = db.GetWorking_Group();
            }
        }

        private void AddWG_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.AddWorking_Group(TB_Title.Text));
            }
            Update();
        }

        private void EditWG_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.EditWorking_Group(db.ConvertorObjectInInt(DGR.SelectedValue), TB_Title.Text));
            }
            Update();
        }

        private void RemoveWG_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ResourceModel())
            {
                MessageBox.Show(db.RemoveWorking_Group(Convert.ToInt32(DGR.SelectedValue)));
            }
            Update();
        }
    }
}
