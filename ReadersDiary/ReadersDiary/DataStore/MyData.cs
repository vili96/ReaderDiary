using ReadersDiary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ReadersDiary.DataStore
{
    class MyData
    {
        public ObservableCollection<Book> books = new ObservableCollection<Book>();
        private static readonly MyData INSTANCE = new MyData();

        private MyData()
        {
            InitializeCollection();
        }

        public static MyData Instance
        {
            get
            {
                return INSTANCE;
            }
        }

        private void InitializeCollection()
        {
            Book it = new Book("It", "Stephen King", "Horror", "it.jpg");
            Book shining = new Book("The Shining", "Stephen King", "Horror", "the_shining.jpg");
            Book greenPath = new Book("The Green Mile", "Stephen King", "Horror", "the_green_mile.jpg");

            this.books.Add(it);
            this.books.Add(shining);
            this.books.Add(greenPath);
        }
    }
}
