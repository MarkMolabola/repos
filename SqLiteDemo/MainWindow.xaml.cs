using SqLiteDemo.Data;
using SqLiteDemo.Model;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SqLiteDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        ProductContext context;
        Product newproduct = new Product();
        public MainWindow(ProductContext _context)
        {
            InitializeComponent();
            context = _context;
        
            ProductDG.ItemsSource = context.Products.ToList();
            AddProductGrid.DataContext = newproduct;
        }
        Product selectedProduct;
        private void UpdateProductforEdit(object sender, RoutedEventArgs e)
        {
           selectedProduct = (sender as FrameworkElement).DataContext as Product;
           UpdateProductGrid.DataContext = selectedProduct;
        }
        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            var product = (sender as FrameworkElement).DataContext as Product;
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
                ProductDG.ItemsSource = context.Products.ToList();
                MessageBox.Show("Product Deleted Successfully");
            }
            else             {
                MessageBox.Show("Please select a product to delete.");
            }
        }
        private void AddProduct(object sender, RoutedEventArgs e)
        {
            context.Products.Add(newproduct);
            context.SaveChanges();
            ProductDG.ItemsSource = context.Products.ToList();
            MessageBox.Show("Product Added Successfully");
            newproduct = new Product();
            AddProductGrid.DataContext = newproduct;
        }
        private void UpdateProduct(object sender, RoutedEventArgs e)
        {
            context.Products.Update(selectedProduct);
            context.SaveChanges();
            ProductDG.ItemsSource = context.Products.ToList();  
        }
    }
}