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
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
            AnimateLoading();
        }

        public async Task AnimateLoading()
        {

            await Task.Delay(1000);
            await logo.ScaleTo(1.3, 1800);
            await logo.FadeTo(0, 500);
            Application.Current.MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.Black,
                BarTextColor = Color.White
            };
        }
    }
}