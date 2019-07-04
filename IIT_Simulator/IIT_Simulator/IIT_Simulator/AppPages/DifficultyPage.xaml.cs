using System;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator.AppPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DifficultyPage : ContentPage
    {
        public DifficultyPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Easy_Clicked(object sender, EventArgs e) => SetDifAndPushPage(1);

        private void Normal_Clicked(object sender, EventArgs e) => SetDifAndPushPage(2);

        private void Hard_Clicked(object sender, EventArgs e) => SetDifAndPushPage(4);

        private async void SetDifAndPushPage(int n)
        {
            await Navigation.PushAsync(new MainPage(n));
        }
    }
}