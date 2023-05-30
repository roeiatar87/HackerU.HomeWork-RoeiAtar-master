using Demos.HackerU.HomeWork;
using Demos.HackerU.HomeWork.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

namespace Demos.HackerU.Wpf
{
    /// <summary>
    /// Interaction logic for StoreWindow.xaml
    /// </summary>
    public partial class StoreWindow : Window
    {
        private IProductsService servProducts;

        public StoreWindow()
        {
            InitializeComponent();
            servProducts = ProductsService.GetInstance();
        }

        /// <summary>
        /// Once When Window is First loaded with all 
        /// Inner Components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Initialization Of GUI WITH DATA
            InitData();
            InitView2();
            //InitView();



        }



        private void InitView()
        {
            //Update CONTROLS With DATA

            //Init  ComboBox Categories
            comboCategories.Items.Clear();
            var categories = servProducts.GetSubCategories(4);
            for (int i = 0; i < categories.Count; i++)
            {
                comboCategories.Items.Add(categories[i].Name);
            }
            comboCategories.Items.Insert(0, "--Please Choose Categories--");
            comboCategories.SelectedIndex = 0;
        }

        private void InitView2()
        {
            //Update CONTROLS With DATA

            //Init  ComboBox Categories
            comboCategoriesTop.Items.Clear();
            var categories = servProducts.GetAllTopLevelCategories();
            for (int i = 0; i < categories.Count; i++)
            {
                comboCategoriesTop.Items.Add(categories[i].Name);
            }
            comboCategoriesTop.Items.Insert(0, "--Please Choose Categories--");
            comboCategoriesTop.SelectedIndex = 0;
        }

        private void InitData()
        {

            //create top level and sub Categories
            StoreCategory c1 = new StoreCategory("Electronics", 0); //id=1
            StoreCategory c2 = new StoreCategory("Laptops", c1.Id); //id=2
            StoreCategory c3 = new StoreCategory("Gadgets", c1.Id);//id=3

            StoreCategory c4 = new StoreCategory("Toys", 0);//id=4
            StoreCategory c5 = new StoreCategory("Games Nintendo", c4.Id);//id=5
            StoreCategory c6 = new StoreCategory("Cards", c4.Id);//id=6

            this.servProducts.AddNewCategories(new StoreCategory[] { c1, c2, c3, c4, c5, c6 });

            // Laptops
            StoreProduct p1 = new StoreProduct(c2.Id, "MAC BOOK", 4000, true);
            StoreProduct p2 = new StoreProduct(c2.Id, "ASUS ZENBOOK", 5000, false);
            StoreProduct p3 = new StoreProduct(c2.Id, "HP ENVY", 11000, true);
            StoreProduct p4 = new StoreProduct(c2.Id, "Dell Vostro", 3100, true);

            //Gadgets
            StoreProduct p5 = new StoreProduct(c3.Id, "Automatic Bottle Opener", 60, true);
            StoreProduct p6 = new StoreProduct(c3.Id, "Mobile Fan", 450, true);


            // Games Nintendo
            StoreProduct p7 = new StoreProduct(c5.Id, "SUPER MARIO", 200, true);
            StoreProduct p8 = new StoreProduct(c5.Id, "FIFA 2023", 300, false);
            StoreProduct p9 = new StoreProduct(c5.Id, "NBA", 100, true);
            StoreProduct p10 = new StoreProduct(c5.Id, "Mine Sweeper", 100, true);

            //Cards
            StoreProduct p11 = new StoreProduct(c6.Id, "Pockimon Cards X10", 200, true);
            StoreProduct p12 = new StoreProduct(c6.Id, "FIFA Cards", 300, false);



            this.servProducts.AddNewProducts(new StoreProduct[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12 });

        }

        private void comboCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ShowData();

        }

        public void ShowData()
        {
            switch (comboCategoriesTop.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    switch (comboCategories.SelectedIndex)
                    {

                        case 0:
                            this.ListBoxProducts.ItemsSource = null;
                            break;

                        case 1:
                            this.ListBoxProducts.ItemsSource = servProducts.GetProductsCategory(2);
                            break;

                        case 2:
                            this.ListBoxProducts.ItemsSource = servProducts.GetProductsCategory(3);
                            break;
                    }

                    break;

                case 2:

                    switch (comboCategories.SelectedIndex)
                    {

                        case 0:
                            this.ListBoxProducts.ItemsSource = null;
                            break;

                        case 1:
                            this.ListBoxProducts.ItemsSource = servProducts.GetProductsCategory(5);
                            break;

                        case 2:
                            this.ListBoxProducts.ItemsSource = servProducts.GetProductsCategory(6);
                            break;
                    }
                    break;
            }

        }

        private void comboCategories_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {

            var categories = new List<StoreCategory>();

            switch (comboCategoriesTop.SelectedIndex)
            {

                case 0:
                    comboCategories.Items.Clear();
                    this.ListBoxProducts.ItemsSource = null;
                    break;
                case 1:
                    comboCategories.Items.Clear();
                    categories = servProducts.GetSubCategories(1);
                    for (int i = 0; i < categories.Count; i++)
                    {
                        comboCategories.Items.Add(categories[i].Name);
                    }
                    comboCategories.Items.Insert(0, "--Please Choose Categories--");
                    comboCategories.SelectedIndex = 0;
                    break;

                case 2:
                    comboCategories.Items.Clear();
                    categories = servProducts.GetSubCategories(4);
                    for (int i = 0; i < categories.Count; i++)
                    {
                        comboCategories.Items.Add(categories[i].Name);
                    }
                    comboCategories.Items.Insert(0, "--Please Choose sub Categories--");
                    comboCategories.SelectedIndex = 0;
                    break;
            }




        }

        private void ListBoxProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var product = this.ListBoxProducts.SelectedItem;

            var o1 = (StoreProduct)product;

            if (ListBoxProducts.SelectedIndex >= 0)
            {
                servProducts.RemoveProduct(o1.Id);
                ListBoxProducts.ItemsSource = servProducts.GetProductsCategory(o1.CategoryId);
            }
            else
            {
                MessageBox.Show("Select item to remove");

            }




        }

        private void AddNewProduct(object sender, RoutedEventArgs e)
        {

            if (comboCategories.SelectedIndex > 0 && comboCategoriesTop.SelectedIndex > 0)
            {
                var selected = comboCategories.SelectedItem;
                var Catlist = servProducts.GetAllCategories();
                var currentCat = Catlist.Find(c => c.Name == selected);

                ProductWindow s = new ProductWindow(currentCat.Id);
                s.ShowDialog();
            }

            else
            {
                MessageBox.Show("select top and sub categories to add product");
            }


        }
    }
}
