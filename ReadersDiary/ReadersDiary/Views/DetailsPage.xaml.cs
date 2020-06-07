using ReadersDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReadersDiary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(Book book)
        {
            InitializeComponent();
            DisplayDataForBook(book);
        }

        private void DisplayDataForBook(Book book)
        {
            if (book != null)
            {
                bookTitle.Text = book.Title;
                bookAuthor.Text = book.Author;
                genre.Text = book.Genre;
                imagePreview.Source = book.ImageUrl;
            }
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopToRootAsync(true);
        }
    }
}