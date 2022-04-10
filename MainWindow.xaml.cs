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
using MaterialDesignThemes.Wpf;


namespace Tome
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static TomeEntities context = new TomeEntities();

        public MainWindow()
        {
            InitializeComponent();

            var menuMerch = new List<SubItem>();
            menuMerch.Add(new SubItem("Футболки"));
            menuMerch.Add(new SubItem("Худи"));
            menuMerch.Add(new SubItem("Свитшоты"));
            menuMerch.Add(new SubItem("Бейсболки"));
            var item2 = new ItemMenu("Мерчи", menuMerch, PackIconKind.AccountBox);

            var menuCollection = new List<SubItem>();
            menuCollection.Add(new SubItem("Новинка"));
            menuCollection.Add(new SubItem("Скидка"));
            menuCollection.Add(new SubItem("Спорт"));
            menuCollection.Add(new SubItem("Музыка"));
            var item1 = new ItemMenu("Коллекции", menuCollection, PackIconKind.ViewDashboard);
                     
            Menu.Children.Add(new UserControlMenuItem(item1));
            Menu.Children.Add(new UserControlMenuItem(item2));

            Manager.MainFrame = mainFrame;
            Manager.DBModel = context;
            Manager.MainFrame.Navigate(new ProductPage());


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти?", "Уведомление", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }

       
    }
}
