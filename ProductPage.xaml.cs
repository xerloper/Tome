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
using System.Data.Entity;

namespace Tome
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public static TomeEntities context = new TomeEntities();

        public ProductPage()
        {
            InitializeComponent();
          
            sortAgentsComboBox.SelectedIndex = 0;
            findAgentsTextBox.Text = "Введите для поиска";

            Manager.products = context.Product.ToList();

            updateContext();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            updateContext();
        }

        public void updateContext()
        {
            try
            {
                List<Product> findProducts = Manager.products.ToList();

                //Поиск
                if (findAgentsTextBox.Text != "Введите для поиска")
                {
                    findProducts = findProducts.Where(t => t.Title.ToLower().Contains(findAgentsTextBox.Text.ToLower()) || t.MerchType.Title == findAgentsTextBox.Text.ToLower()).ToList();
                   
                }

                //Сортировка
                switch (sortAgentsComboBox.SelectedIndex)
                {
                    case 0: findProducts = findProducts.OrderBy(t => t.Title).ToList(); break;
                    case 1: findProducts = findProducts.OrderByDescending(t => t.Title).ToList(); break;
                    case 2: findProducts = findProducts.OrderBy(t => t.Price).ToList(); break;
                    case 3: findProducts = findProducts.OrderByDescending(t => t.Price).ToList(); break;                  
                }

                agentsListView.ItemsSource = findProducts;
         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButton.OK);
            }
        }

        private void findAgentsTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (findAgentsTextBox.Text == "Введите для поиска")
                findAgentsTextBox.Clear();
            else if (findAgentsTextBox.Text == "")
                findAgentsTextBox.Text = "Введите для поиска";
        }

        private void sortAgentsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateContext();
        }

        private void filtTypeAgentsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateContext();
        }

        private void findAgentsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateContext();
        }

    }
}
