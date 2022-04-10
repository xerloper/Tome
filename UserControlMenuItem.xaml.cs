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
using Tome.View.ViewModel;


namespace Tome
{
    /// <summary>
    /// Логика взаимодействия для UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {

        public UserControlMenuItem(ItemMenu itemMenu)
        {
            InitializeComponent();

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new ProductPage());

            switch ((sender as TextBlock).Text)
            {
                case "Футболки":Manager.products= Manager.DBModel.Product.Where(t => t.MerchType.Title == "Футболка").ToList(); break;
                case "Худи": Manager.products = Manager.DBModel.Product.Where(t => t.MerchType.Title == "Худи").ToList(); break;
                case "Свитшоты": Manager.products = Manager.DBModel.Product.Where(t => t.MerchType.Title == "Свитшот").ToList(); break;
                case "Бейсболки": Manager.products = Manager.DBModel.Product.Where(t => t.MerchType.Title == "Бейсболка").ToList(); break;
                case "Новинка": Manager.products = Manager.DBModel.Product.Where(t => t.Price <= 1000).ToList(); break;
                case "Скидки": Manager.products = Manager.DBModel.Product.Where(t => t.Price >= 3000).ToList(); break;
                case "Спорт": Manager.products = Manager.DBModel.Product.Where(t => t.Price >= 2000 &&  t.Price <= 3000).ToList(); break;
                case "Музыка": Manager.products = Manager.DBModel.Product.Where(t => t.Price >= 1000 && t.Price <= 2000).ToList(); break;
                default: Manager.products = Manager.DBModel.Product.ToList(); break;
            }
        }
    }
}
