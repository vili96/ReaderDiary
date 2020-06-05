using ReadersDiary.Models;
using ReadersDiary.Services;
using ReadersDiary.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ReadersDiary
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            collectionViewBooks.ItemsSource = BookService.GetAllBooks();
        }

        private void EditMenuItem_Clicked(object sender, EventArgs e)
        {
            foreach (Book book in collectionViewBooks.ItemsSource)
            {
                book.IsEditable = true;
            }
            Navigation.PushAsync(new MainPage());
        }

        private void AllBooksMenuItem_Clicked(object sender, EventArgs e)
        {
            foreach (Book book in collectionViewBooks.ItemsSource)
            {
                book.IsEditable = false;
            }
            Navigation.PushAsync(new MainPage());
        }

        private void AddMenuItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddPage());
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var itemsender = (Button)sender;
            var item = (Book)itemsender?.CommandParameter;
            BookService.RemoveBook(item);
        }

        private void EditBtn_Clicked(object sender, EventArgs e)
        {
            var itemsender = (Button)sender;
            var item = (Book)itemsender?.CommandParameter;
            Navigation.PushAsync(new AddPage(item));
        }
    }
}
