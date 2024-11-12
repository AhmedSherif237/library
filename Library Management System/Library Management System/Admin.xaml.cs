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

namespace Library_Management_System
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        LibrarySystemEntities db = new LibrarySystemEntities();
        public Admin()
        {
            InitializeComponent();
            adminGrid.ItemsSource = db.books.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            book book = new book();
            book.BookTitle = bookTitle.Text;
            book.Author = bookAuther.Text;
            book.Quantity = int.Parse(bookQuantity.Text);
            db.books.Add(book);
            db.SaveChanges();
            MessageBox.Show("Data Add");
            adminGrid.ItemsSource = db.books.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int idFromTxt = int.Parse(bookId.Text);
            book book = db.books.Remove(db.books.First(x => x.BookId == idFromTxt));
            MessageBox.Show("Data Deleted");
            db.SaveChanges();
            adminGrid.ItemsSource = db.books.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            adminGrid.ItemsSource = db.books.ToList();
            NavigationService.Navigate(new Welcome());
        }
    }
}
