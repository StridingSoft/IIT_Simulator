using System;
using System.IO;
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
            SavingSystem.ReadFile();
            States.RefreshLabels();
            States.RefreshProgressBars();
        }

        private void btnEat_Click(object sender, EventArgs e)
        {
            States.Satiety += 20;
            States.RefreshLabels();
            States.RefreshProgressBars();
            ForceGameOverAlert();
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {

        }

        private void btnEnjoy_Click(object sender, EventArgs e)
        {

        }

        private async void ForceGameOverAlert()
        {
            if (States.GameOver())
            {
                await DisplayAlert("Вы проиграли!", "Студент умер. Начните сначала", "ОК");
                await Navigation.PushAsync(new Menu());
            }
        }

        protected override void OnDisappearing()
        {
            File.Delete(SavingSystem.GetPathToFile());
            if(!States.GameOver())
                SavingSystem.WriteAllData(SavingSystem.GetPathToFile());
        }
    }
}