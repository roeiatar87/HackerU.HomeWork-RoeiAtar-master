using Demos.HackerU.HomeWork;
using Demos.HackerU.HomeWork.Store;
using Nest;
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

namespace Demos.HackerU.Wpf
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public int Categoryid = -1;
        public decimal price = 0;
        public string name = string.Empty;
        public bool inStock = true;
        private IProductsService servProducts;
        public ProductWindow()
        {
            InitializeComponent();
        }

        public ProductWindow(int categoryid)
        {
            Categoryid = categoryid;
            InitializeComponent();
            servProducts = ProductsService.GetInstance();
        }



        private void inStock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxInStock.SelectedIndex == 1)
            {
                inStock = true;
            }
            else { inStock = false; }


        }

        private void PriceBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string priceBox = txtPrice.Text;
            decimal num;
            bool isConvertedOk = decimal.TryParse(priceBox, out num);
            if (isConvertedOk)
            {
                price = num;
            }
            else
            {
                price = 0;
            }
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            name = txtName.Text;
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            servProducts.AddNewProduct(name, price, inStock, Categoryid);
            Close();



        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            bool[] bools = { true, false };
            comboBoxInStock.Items.Clear();
            comboBoxInStock.Items.Insert(0, "select value");
            comboBoxInStock.SelectedIndex = 0;
            comboBoxInStock.Items.Add(bools[0]);
            comboBoxInStock.Items.Add(bools[1]);
        }
    }
}
