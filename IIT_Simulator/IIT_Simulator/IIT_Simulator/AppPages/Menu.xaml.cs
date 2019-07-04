using IIT_Simulator.AppPages;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : ContentPage
	{
        public bool Continue = false;
        private int courses;
		public Menu ()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
		}

        private async void GameStart_Clicked(object sender, EventArgs e)
        {
            CheckFile();
            if (!Continue)
                await Navigation.PushAsync(new DifficultyPage());
            else
                await Navigation.PushAsync(new MainPage(courses));
        }


        private void Exit_Clicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void CheckFile()
        {
            string fileName = SavingSystem.GetPathToFile("data.txt");
            if (File.Exists(fileName))
            {
                Continue = true;
                using (var streamReader = new StreamReader(fileName))
                {
                    var array = streamReader.ReadToEnd().Trim().Split(';');
                    courses = int.Parse(array[22]);
                }
            }
            else Continue = false;
        }

        private async void Achievements_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Achievements());
        }
    }
}