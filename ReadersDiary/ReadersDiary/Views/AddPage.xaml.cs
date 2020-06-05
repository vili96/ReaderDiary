using ReadersDiary.Models;
using ReadersDiary.Services;
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
    public partial class AddPage : ContentPage
    {
        Book CurrentBook;
        public AddPage()
        {
            InitializeComponent();
        }

        public AddPage(Book book)
        {
            InitializeComponent();
            CurrentBook = book;
            PopulateFieldValues();
        }

        private void PopulateFieldValues()
        {
            bookTitle.Text = CurrentBook.Title != null ? CurrentBook.Title : "";
            bookAuthor.Text = CurrentBook.Author != null ? CurrentBook.Author : "";
            genre.SelectedItem = CurrentBook.Genre != null ? CurrentBook.Genre : "";
            imagePreview.Source = CurrentBook.ImageUrl;
        }

        async private void UploadImage_Clicked(object sender, EventArgs e)
        {
            //await CrossMedia.Current.Initialize();
            //if (!CrossMedia.Current.IsPickPhotoSupported)
            //{
            //    await DisplayAlert("Not supported", "Functionality not supported on your device.", "Ok");
            //    return;
            //}

            //var mediaOptions = new PickMediaOptions()
            //{
            //    PhotoSize = PhotoSize.Medium
            //};
            //var selectedImage = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            //if (selectedImage == null)
            //{
            //    await DisplayAlert("Error", "Could not upload image, please try again", "Ok");
            //    return;
            //}

            //imagePreview.Source = ImageSource.FromStream(() => selectedImage.GetStream());

        }

        private void SaveBook_Clicked(object sender, EventArgs e)
        {
            string title = bookTitle.Text != null ? bookTitle.Text.Trim() : "";
            string author = bookAuthor.Text != null ? bookAuthor.Text.Trim() : "";
            string genreStr = "";

            if (genre.SelectedItem != null)
            {
                genreStr = genre.SelectedItem.ToString();
            }
            else
            {
                DisplayAlert("Error", "Please select genre!", "Ok");
                return;
            }

            if (title.Length > 0 && author.Length > 0 && genreStr.Length > 0)
            {
                if (CurrentBook == null)
                {
                    CurrentBook = new Book(title, author, genreStr, "default_cover.jpg");
                    CurrentBook.IsEditable = false;
                    BookService.AddBook(CurrentBook);
                }
                else
                {
                    int index = BookService.GetBookIndex(CurrentBook);
                    Book bookToEdit = BookService.GetBookByIndex(index);
                    bookToEdit.Title = title;
                    bookToEdit.Author = author;
                    bookToEdit.Genre = genreStr;
                    bookToEdit.IsEditable = false;
                    BookService.EditBookAt(index, bookToEdit);
                }

                this.Navigation.PopToRootAsync();
            }
            else
            {
                DisplayAlert("Error", "All fields are required!", "Ok");
            }
        }
    }
}