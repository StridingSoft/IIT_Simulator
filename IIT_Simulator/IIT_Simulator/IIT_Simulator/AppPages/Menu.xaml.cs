using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : ContentPage
	{
		public Menu ()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
		}

        private async void GameStart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }


        private void Exit_Clicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private async void HowToPlay_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HowToPlay());
        }
    }
}