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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for rfq_products_info.xaml
    /// </summary>
    public partial class rfq_products_info : Page
    {

        common_queries commonQueries = new common_queries();
        BASIC_STRUCTS.PRODUCT_INFO[] products;
        List<int> productID=new List<int>();
        List<int> brandId=new List<int>();
        List<int>modelId=new List<int>();

        List<int> productID2 = new List<int>();
        List<int> brandId2 = new List<int>();
        List<int> modelId2 = new List<int>();

        List<int> productID3 = new List<int>();
        List<int> brandId3 = new List<int>();
        List<int> modelId3 = new List<int>();

        List<int> productID4 = new List<int>();
        List<int> brandId4 = new List<int>();
        List<int> modelId4 = new List<int>();
        public static List<BASIC_STRUCTS.PRODUCT_INFO> productsInfo = new List<BASIC_STRUCTS.PRODUCT_INFO>();
        BASIC_STRUCTS.PRODUCT_INFO product=new BASIC_STRUCTS.PRODUCT_INFO();

  


        public rfq_products_info()
        {
            InitializeComponent();
            product1CheckBox.IsChecked = true;
            product1CheckBox.IsEnabled = false;

            
            typeComboBox.IsEnabled = false;
            typeComboBoxPrdoduct2.IsEnabled = false;
            typeComboBoxProduct3.IsEnabled = false;
            typeComboBoxProduct4.IsEnabled = false;

            brandComboBox.IsEnabled = false;
            brandComboBoxProduct2.IsEnabled = false;
            brandComboBoxProduct3.IsEnabled = false;
            brandComboBoxProduct4.IsEnabled = false;

            modelComboBox.IsEnabled = false;
            modelComboBoxPrduct2.IsEnabled = false;
            modelComboBoxProduct3.IsEnabled = false;
            modelComboBoxProduct4.IsEnabled = false;

            quantityTextBox.IsEnabled = false;
            quantityTextBoxProduct2.IsEnabled = false;
            quantityTextBoxProduct3.IsEnabled = false;
            quantityTextBoxProduct4.IsEnabled = false;


            if (product1CheckBox.IsChecked == true)
            {

                typeComboBox.IsEnabled = true;
                brandComboBox.IsEnabled = true;
                modelComboBox.IsEnabled = true;
                quantityTextBox.IsEnabled = true;
            }
            else
            {
                typeComboBox.IsEnabled = false;
                brandComboBox.IsEnabled = false;
                modelComboBox.IsEnabled = false;
                quantityTextBox.IsEnabled = false;
            }
            products = commonQueries.GetProducts();
            for(int i=0; i<products.Length;i++)
            {
                if (typeComboBox.Items.Contains(products[i].product_name))
                    continue;
                typeComboBox.Items.Add(products[i].product_name);
                productID.Add(products[i].product_id);
            }
            

        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new rfq_basic_info());
        }

        private void Label_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new rfq_products_info());
        }

        private void Label_MouseDoubleClick_2(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new rfq_upload_files());
        }

        private void Label_MouseDoubleClick_3(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new additional_info());
        }

        private void product2CheckBox_Click(object sender, RoutedEventArgs e)
        {
           if(product2CeckBox.IsChecked == false)
            {
                typeComboBoxPrdoduct2.IsEnabled = false;
                brandComboBoxProduct2.IsEnabled = false;
                modelComboBoxPrduct2.IsEnabled = false;
                quantityTextBoxProduct2.IsEnabled = false;

                typeComboBoxPrdoduct2.Items.Clear();
                brandComboBoxProduct2.Items.Clear();
                modelComboBoxPrduct2.Items.Clear();
                quantityTextBoxProduct2.Clear();
            }
           else
            {
                typeComboBoxPrdoduct2.IsEnabled = true;
                brandComboBoxProduct2.IsEnabled = true;
                modelComboBoxPrduct2.IsEnabled = true;
                quantityTextBoxProduct2.IsEnabled = true;

                for (int i = 0; i < products.Length; i++)
                {
                    if (typeComboBoxPrdoduct2.Items.Contains(products[i].product_name))
                        continue;
                    typeComboBoxPrdoduct2.Items.Add(products[i].product_name);
                    productID2.Add(products[i].product_id);
                }
            }
        }

        private void Product3CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(Product3CheckBox.IsChecked == false)
            {
                typeComboBoxProduct3.IsEnabled = false;
                brandComboBoxProduct3.IsEnabled = false;
                modelComboBoxProduct3.IsEnabled = false;
                quantityTextBoxProduct3.IsEnabled = false;

                typeComboBoxProduct3.Items.Clear();
                brandComboBoxProduct3.Items.Clear();
                modelComboBoxProduct3.Items.Clear();
                quantityTextBoxProduct3.Clear();
            }
            else
            {
                typeComboBoxProduct3.IsEnabled = true;
                brandComboBoxProduct3.IsEnabled = true;
                modelComboBoxProduct3.IsEnabled = true;
                quantityTextBoxProduct3.IsEnabled = true;

                for (int i = 0; i < products.Length; i++)
                {
                    if (typeComboBoxProduct3.Items.Contains(products[i].product_name))
                        continue;
                    typeComboBoxProduct3.Items.Add(products[i].product_name);
                    productID3.Add(products[i].product_id);
                }
            }
        }

        private void product4CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(product4CheckBox.IsChecked==false)
            {
                typeComboBoxProduct4.IsEnabled = false;
                brandComboBoxProduct4.IsEnabled = false;
                modelComboBoxProduct4.IsEnabled = false;
                quantityTextBoxProduct4.IsEnabled = false;

                typeComboBoxProduct4.Items.Clear();
                brandComboBoxProduct4.Items.Clear();
                modelComboBoxProduct4.Items.Clear();
                quantityTextBoxProduct4.Clear();
            }
            else
            {
                typeComboBoxProduct4.IsEnabled = true;
                brandComboBoxProduct4.IsEnabled = true;
                modelComboBoxProduct4.IsEnabled = true;
                quantityTextBoxProduct4.IsEnabled = true;

                for (int i = 0; i < products.Length; i++)
                {
                    if (typeComboBoxProduct4.Items.Contains(products[i].product_name))
                        continue;
                    typeComboBoxProduct4.Items.Add(products[i].product_name);
                    productID4.Add(products[i].product_id);
                }
            }
        }

        private void brandComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            modelComboBox.Items.Clear();
            if (!brandComboBox.Items.IsEmpty)
            {
                for (int i = 0; i < products.Length; i++)
                {
                    if (brandId[brandComboBox.SelectedIndex] == products[i].brand_id)
                    {
                        if (modelComboBox.Items.Contains(products[i].model_name))
                            continue;
                        modelComboBox.Items.Add(products[i].model_name);
                        modelId.Add(products[i].model_id);
                    }
                }

                product.brand_id = brandId[brandComboBox.SelectedIndex];
            }
        }

        private void typeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            brandComboBox.Items.Clear();
            brandId.Clear();
            for(int i=0; i<products.Length;i++)
            {
                if (productID[typeComboBox.SelectedIndex] == products[i].product_id)
                {
                    if (brandComboBox.Items.Contains(products[i].brand_name))
                        continue;
                    brandComboBox.Items.Add(products[i].brand_name);
                    brandId.Add(products[i].brand_id);
                }
            }

            product.product_id = productID[typeComboBox.SelectedIndex];
        }

        private void typeComboBoxPrdoduct2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            brandComboBoxProduct2.Items.Clear();
            brandId2.Clear();
            if (!typeComboBoxPrdoduct2.Items.IsEmpty)
            for (int i = 0; i < products.Length; i++)
            {
                if (productID2[typeComboBoxPrdoduct2.SelectedIndex] == products[i].product_id)
                {
                    if (brandComboBoxProduct2.Items.Contains(products[i].brand_name))
                        continue;
                    brandComboBoxProduct2.Items.Add(products[i].brand_name);
                    brandId2.Add(products[i].brand_id);
                }
            }
            product.product_id = productID2[typeComboBoxPrdoduct2.SelectedIndex];
        }

        private void brandComboBoxProduct2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            modelComboBoxPrduct2.Items.Clear();

            if (!brandComboBoxProduct2.Items.IsEmpty)
            {
                for (int i = 0; i < products.Length; i++)
                {
                    if (brandId2[brandComboBoxProduct2.SelectedIndex] == products[i].brand_id)
                    {
                        if (modelComboBoxPrduct2.Items.Contains(products[i].model_name))
                            continue;
                        modelComboBoxPrduct2.Items.Add(products[i].model_name);
                        modelId2.Add(products[i].model_id);
                    }
                }
                product.brand_id = brandId2[brandComboBoxProduct2.SelectedIndex];
            }
        }

        

        private void typeComboBoxProduct3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            brandComboBoxProduct3.Items.Clear();
            brandId3.Clear();
            if (!typeComboBoxProduct3.Items.IsEmpty)
                for (int i = 0; i < products.Length; i++)
                {
                    if (productID3[typeComboBoxProduct3.SelectedIndex] == products[i].product_id)
                    {
                        if (brandComboBoxProduct3.Items.Contains(products[i].brand_name))
                            continue;
                        brandComboBoxProduct3.Items.Add(products[i].brand_name);
                        brandId3.Add(products[i].brand_id);
                    }
                }
            product.product_id = productID3[typeComboBoxProduct3.SelectedIndex];
        }

        private void brandComboBoxProduct3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            modelComboBoxProduct3.Items.Clear();
            if (!brandComboBoxProduct3.Items.IsEmpty)
            {
                for (int i = 0; i < products.Length; i++)
                {
                    if (brandId3[brandComboBoxProduct3.SelectedIndex] == products[i].brand_id)
                    {
                        if (modelComboBoxProduct3.Items.Contains(products[i].model_name))
                            continue;
                        modelComboBoxProduct3.Items.Add(products[i].model_name);
                        modelId3.Add(products[i].model_id);
                    }
                }
                product.brand_id = brandId3[brandComboBoxProduct3.SelectedIndex];
            }
        }

        private void typeComboBoxProduct4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            brandComboBoxProduct4.Items.Clear();
            brandId4.Clear();
            if (!typeComboBoxProduct4.Items.IsEmpty)
                for (int i = 0; i < products.Length; i++)
                {
                    if (productID4[typeComboBoxProduct4.SelectedIndex] == products[i].product_id)
                    {
                        if (brandComboBoxProduct4.Items.Contains(products[i].brand_name))
                            continue;
                        brandComboBoxProduct4.Items.Add(products[i].brand_name);
                        brandId4.Add(products[i].brand_id);
                    }
                }
            product.product_id = productID4[typeComboBoxProduct4.SelectedIndex];
        }

        private void brandComboBoxProduct4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            modelComboBoxProduct4.Items.Clear();
            if (!brandComboBoxProduct4.Items.IsEmpty)
            {
                for (int i = 0; i < products.Length; i++)
                {
                    if (brandId4[brandComboBoxProduct4.SelectedIndex] == products[i].brand_id)
                    {
                        if (modelComboBoxProduct4.Items.Contains(products[i].model_name))
                            continue;
                        modelComboBoxProduct4.Items.Add(products[i].model_name);
                        modelId4.Add(products[i].model_id);
                    }
                }
                product.brand_id = brandId4[brandComboBoxProduct4.SelectedIndex];
            }
        }

        private void modelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(modelComboBox.SelectedIndex!=-1)
            product.model_id = modelId[modelComboBox.SelectedIndex];
        }

        private void modelComboBoxPrduct2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (modelComboBoxPrduct2.SelectedIndex != -1)
                product.model_id = modelId2[modelComboBoxPrduct2.SelectedIndex];
        }

        private void modelComboBoxProduct3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (modelComboBoxProduct3.SelectedIndex != -1)
                product.model_id = modelId3[modelComboBoxProduct3.SelectedIndex];
        }

        private void modelComboBoxProduct4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (modelComboBoxProduct4.SelectedIndex != -1)
                product.model_id = modelId4[modelComboBoxProduct4.SelectedIndex];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (quantityTextBox.IsEnabled == true)
                {
                    product.quantity = Int32.Parse(quantityTextBox.Text);
                    productsInfo.Add(product);
                }
                if (quantityTextBoxProduct2.IsEnabled == true)
                {
                    product.quantity = Int32.Parse(quantityTextBoxProduct2.Text);
                    productsInfo.Add(product);
                }
                if (quantityTextBoxProduct3.IsEnabled == true)
                {
                    product.quantity = Int32.Parse(quantityTextBoxProduct3.Text);
                    productsInfo.Add(product);
                }
                if (quantityTextBoxProduct4.IsEnabled == true)
                {
                    product.quantity = Int32.Parse(quantityTextBoxProduct4.Text);
                    productsInfo.Add(product);
                }
                NavigationService.Navigate(new additional_info());
            }
            catch(FormatException E)
            {
                MessageBox.Show("Please enter intger vales in the quantity");
            }
          
        }
    }
}
