using ReadersDiary.DataStore;
using ReadersDiary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ReadersDiary.Services
{
    class BookService
    {
        static MyData MyData = MyData.Instance;

        static public ObservableCollection<Book> GetAllBooks()
        {
            return MyData.books;
        }

        static public void RemoveBook(Book book)
        {
            MyData.books.Remove(book);
        }

        static public void AddBook(Book book)
        {
            MyData.books.Add(book);
        }

        static public void EditBookAt(int index, Book book)
        {
            MyData.books[index] = book;
        }

        static public Book GetBookByIndex(int index)
        {
            return MyData.books[index];
        }

        static public int GetBooksCount()
        {
            return MyData.books.Count;
        }

        static public int GetBookIndex(Book book)
        {
            return MyData.books.IndexOf(book);
        }

        static public ObservableCollection<Book> GetAllBooksByGenre(string genre)
        {
            ObservableCollection<Book> filteredBooks = new ObservableCollection<Book>();

            foreach (var item in MyData.books)
            {
                if (item.Genre == genre)
                {
                    filteredBooks.Add(item);
                }
            }
            return filteredBooks;
        }
    }
}
