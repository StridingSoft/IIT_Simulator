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
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
		}

        private void GameStart_Clicked(object sender, EventArgs e)
        {
            new Animation(opacity => this.Opacity = opacity / 100, 100, 0)
            .Commit(this, "PageExitAnimation", 1, 350, Easing.CubicInOut, async(d, b) =>
            {
                var mainPage = new MainPage() { Opacity = 0 }; // Create the page with 0 opacity to animate later
                await Navigation.PushAsync(mainPage, false); // Push the new page, as the current page is already with 0 opacity, without animation
                await mainPage.FadeTo(1, 350, Easing.CubicInOut); // Animate the fade of the next page
                this.Opacity = 100;
            });
        }

        private void Exit_Clicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}