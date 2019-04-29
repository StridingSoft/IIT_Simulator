using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Needs : ContentPage
    {
        Random rnd = new Random();

        public Needs()
        {
            InitializeComponent();
            States.InitializeStates();
            States.RefreshLabels();
        }

        private void btnEat_Click(object sender, EventArgs e)
        {
            States.Satiety += 20;
            States.RefreshLabels();
            CheckStates();
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {

        }

        private void btnEnjoy_Click(object sender, EventArgs e)
        {

        }

        private async void CheckStates()
        {
            if (States.GameOver())
            {
                await DisplayAlert("Вы проиграли!", "Студент умер. Начать сначала?", "ОК");
                await Navigation.PushAsync(new Menu());
            }
        }
    }
}