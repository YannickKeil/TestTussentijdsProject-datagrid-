using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

namespace TestTussentijdsProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TestProjectEntities dataEntities = new TestProjectEntities();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query =
                from Author in dataEntities.Authors
                //where Author.city == "Oakland"
                orderby Author.au_lname
                select new { Voornaam = Author.au_fname, Achternaam = Author.au_lname, Author.phone, Author.address, Author.city, Author.state, Author.zip };

            dataGrid1.ItemsSource = query.ToList();
        }
    }
}
