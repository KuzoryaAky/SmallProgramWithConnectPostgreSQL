using System.Linq;
using System.Windows;
using UI_test.DBConnect;
using UI_test.Products;


namespace UI_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CProducts products;
        public MainWindow()
        {
            InitializeComponent();
            products = new ();
        }

        private void Button_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            MProduct product = new()
            {
                ProductName = TB_ProductName.Text,
                Manufacture = TB_Manufacturer.Text,
                ProductCount = int.Parse(TB_ProductCount.Text),
                Price = float.Parse(TB_Price.Text),
            };

            products.Add (product);
            
            TB_ProductName.Text = "";
            TB_Manufacturer.Text = "";
            TB_ProductCount.Text = "";
            TB_Price.Text = "";
        }

        private void Button_ShowDataInProgram_Click(object sender, RoutedEventArgs e)
        {
            LB_DataShowList.Items.Clear();
            int count = 0;
            foreach (MProduct item in CProducts.products)
            {
                LB_DataShowList.Items.Add($"Id: {++count}");
                LB_DataShowList.Items.Add($"Name:{item.ProductName}");
                LB_DataShowList.Items.Add($"Manufacture{item.Manufacture}");
                LB_DataShowList.Items.Add($"Count{item.ProductCount}");
                LB_DataShowList.Items.Add($"Price{item.Price}");
            }
        }

        private void Button_ClearList_Click(object sender, RoutedEventArgs e)
        {
            LB_DataShowList.Items.Clear();
        }

        private void Button_AddConfirm_Click(object sender, RoutedEventArgs e)
        {
            using(ApplicationContext db = new())
            {
                foreach (MProduct item in CProducts.products)
                    db.products.Add(item);

                db.SaveChanges();
            }
        }

        private void Button_ShowResultInDB_Click(object sender, RoutedEventArgs e)
        {
            LB_DataShowList.Items.Clear();
            using (ApplicationContext db = new())
            {
                var products = db.products.ToList();
                LB_DataShowList.Items.Add("Product list");
                foreach (MProduct product in products)
                {
                    LB_DataShowList.Items.Add($"Id: {product.Id}");
                    LB_DataShowList.Items.Add($"Name: {product.ProductName}");
                    LB_DataShowList.Items.Add($"Manufacturer: {product.Manufacture}");
                    LB_DataShowList.Items.Add($"Count: {product.ProductCount}");
                    LB_DataShowList.Items.Add($"Price: {product.Price}");
                }
            }
        }
    }
}
