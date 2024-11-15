﻿using System;
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

namespace library
{
    /// <summary>
    /// Interaction logic for user.xaml
    /// </summary>
    public partial class user : Page
    {
        libraryEntities3 db = new libraryEntities3();
        public user()
        {
            InitializeComponent();
            RefreshBooksTable();
            RefreshBorrowTable();
        }

        public void RefreshBooksTable()
        {
            Books_Table.ItemsSource = db.books.ToList();
        }
        public void RefreshBorrowTable()
        {
            borrow_table.ItemsSource = db.borrows.ToList();
        }
        private void Borrow_Click(object sender, RoutedEventArgs e)
        {
            book selectedBook = Books_Table.SelectedItem as book;

            if (selectedBook != null)
            {
                if (selectedBook.Quantity == 0)
                {
                    MessageBox.Show("this book is not Available");
                }
                else
                {
                    selectedBook.Quantity--;

                    borrow borrowedItem = db.borrows.FirstOrDefault(x => x.CustomerName == custome_name.Text && x.ReturnDate == return_date.Text && selectedBook.BookId == x.BookId);

                    if (borrowedItem != null)
                    {
                        borrowedItem.Quantity += 1;
                    }
                    else
                    {
                        borrow borrow = new borrow
                        {
                            CustomerName = custome_name.Text,
                            BookId = selectedBook.BookId,
                            Quantity = 1,
                            BookTitle = selectedBook.BookTitle.ToString(),
                            BorrowDate = DateTime.Now,
                            ReturnDate = return_date.Text
                        };

                        db.borrows.Add(borrow);

                    }
                    db.SaveChanges();
                    RefreshBorrowTable();
                    RefreshBooksTable();
                }
            }
        }
        private void ReturnBorrow_Click(object sender, RoutedEventArgs e)
        {
            borrow borrow = borrow_table.SelectedItem as borrow;

            if (borrow != null)
            {

                book BorrowedBook = db.books.FirstOrDefault(x => x.BookId == borrow.BookId);

                BorrowedBook.Quantity += borrow.Quantity;
                db.borrows.Remove(borrow);

                db.SaveChanges();
                RefreshBorrowTable();
                RefreshBooksTable();
            }
        }
    }
 }
