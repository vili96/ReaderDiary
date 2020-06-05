using System;
using System.Collections.Generic;
using System.Text;

namespace ReadersDiary.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ImageUrl { get; set; }
        public bool IsEditable { get; set; }

        public Book() { }
        public Book(string title, string author, string genre, string imageUrl)
        {
            Title = title;
            Author = author;
            Genre = genre;
            ImageUrl = imageUrl;
        }
    }
}
