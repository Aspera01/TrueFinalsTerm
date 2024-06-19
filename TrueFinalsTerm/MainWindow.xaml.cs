using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Data.Linq;
using System.Linq;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;


namespace TrueFinalsTerm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataClasses1DataContext _dbConn = null;
        bool flag = false;
        bool mode = false; //false = user | true = moderator

        private readonly ObservableCollection<ProductViewModel> _productViewModels;
        public IEnumerable<ProductViewModel> ProductViewModels => _productViewModels;
        public MainWindow()
        {
            InitializeComponent();
            _dbConn = new DataClasses1DataContext(Properties.Settings.Default.PickShopDBConnectionString);

            _productViewModels = new ObservableCollection<ProductViewModel>()
            {
                new ProductViewModel(@"C:\Users\Aspera01\source\repos\TrueFinalsTerm\TrueFinalsTerm\Background\image.png","Tshirt", "Gucci replica", 100.00),
                new ProductViewModel(@"C:\Users\Aspera01\source\repos\TrueFinalsTerm\TrueFinalsTerm\Background\Tesla.png","Honda Civic", "120,000km", 10000000.00),
                new ProductViewModel(@"C:\Users\Aspera01\source\repos\TrueFinalsTerm\TrueFinalsTerm\Background\image.png","Alpha", "I dunno", 100.00),
                new ProductViewModel(@"C:\Users\Aspera01\source\repos\TrueFinalsTerm\TrueFinalsTerm\Background\gigachadd.png","Torotot", "Bruh", 3000.00),
                new ProductViewModel(@"C:\Users\Aspera01\source\repos\TrueFinalsTerm\TrueFinalsTerm\Background\image.png","Omega", "Test", 100.00),
                new ProductViewModel(@"C:\Users\Aspera01\source\repos\TrueFinalsTerm\TrueFinalsTerm\Background\image.png", "Adult Item", "The d", 3000.00),
                new ProductViewModel(@"C:\Users\Aspera01\source\repos\TrueFinalsTerm\TrueFinalsTerm\Background\image.png","Iphone 12 pro", "Used", 300.00)
            };

            DataContext = this;
            //this.WindowState = WindowState.Maximized;
            //this.WindowStyle = WindowStyle.None;
            //this.ResizeMode = ResizeMode.NoResize;

        }

        private void Shopping_Click(object sender, RoutedEventArgs e)
        {
            SellingItems.Visibility = Visibility.Collapsed;
            listedItems.Visibility = Visibility.Visible;
        }

        private void Selling_Click(object sender, RoutedEventArgs e)
        {
            listedItems.Visibility = Visibility.Collapsed;
            SellingItems.Visibility = Visibility.Visible;

        }

        private void Contact_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SignIn_click(object sender, RoutedEventArgs e)
        {
            if (user_box.Text.Length > 0 && pass_box.Text.Length > 0)
            {
                flag = false;
                string messageString = "";
                IQueryable<_User> selectResults = from s in _dbConn._Users
                                                  where s.User_Name.Trim() == user_box.Text
                                                  select s;
                if (selectResults.Count() == 1)
                {
                    //MessageBox.Show("works");
                    foreach (_User s in selectResults)
                    {
                        if (s.User_Pass.Trim() == pass_box.Text)
                        {
                            if (s.User_ID.Trim() == "U_1")
                            {
                                mode = false;
                            }
                            else if (s.User_ID.Trim() == "U_2")
                            {
                                mode = true;
                            }

                            if (!mode)
                            {
                                login.Visibility = Visibility.Collapsed;
                                listedItems.Visibility = Visibility.Visible;
                                messageString = s.User_Name + "\n" + s.User_Num + "\n" + s.User_Email + "\n" + s.User_ID;
                                MessageBox.Show(messageString);
                                break;
                            }
                            else
                            {

                                login.Visibility = Visibility.Collapsed;
                                listedItems.Visibility = Visibility.Visible;
                                messageString = s.User_Name + "\n" + s.User_Num + "\n" + s.User_Email + "\n" + s.User_ID;
                                MessageBox.Show(messageString);
                                break;
                            }

                        }
                        else if (s.User_Pass.Trim() != pass_box.Text)
                        {
                            messageString = "Incorrect Password.\n" +
                                "Try again!";
                            MessageBox.Show(messageString);
                        }
                    }

                }
            }



            //MessageBox.Show(user_box.Text + " " + pass_box.Text);
        }
    }
}

