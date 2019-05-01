using IIT_Simulator.Classes;
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
            if (CashControl.Money >= 100)
            {
                States.Satiety += 20 + rnd.Next(1, 10);
                States.Sleep -= rnd.Next(1, 7);
                CashControl.Money -= 100;
                DaysControl.DecreaseDays();
                States.RefreshLabels();
                States.RefreshProgressBars();
                Studies.RefreshStates();
                ForceGameOverAlert();
            }
            else
                ForceNoMoneyAlert();
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            States.Sleep += 20 + rnd.Next(1, 10);
            States.Satiety -= rnd.Next(1, 7);
            DaysControl.DecreaseDays();
            States.RefreshLabels();
            States.RefreshProgressBars();
            Studies.RefreshStates();
            ForceGameOverAlert();
        }

        private void btnEnjoy_Click(object sender, EventArgs e)
        {
            if (CashControl.Money >= 200)
            {
                States.Happiness += 30 + rnd.Next(1, 10);
                States.Satiety -= rnd.Next(5, 15);
                States.Sleep -= rnd.Next(5, 15);
                CashControl.Money -= 200;
                DaysControl.DecreaseDays();
                States.RefreshLabels();
                States.RefreshProgressBars();
                Studies.RefreshStates();
                ForceGameOverAlert();
            }
            else
                ForceNoMoneyAlert();
        }

        private async void ForceNoMoneyAlert() => await DisplayAlert("Недостаточно средств", "У вас закончились деньги", "ОК");

        private async void ForceGameOverAlert()
        {
            if (States.GameOver())
            {
                await DisplayAlert("Вы проиграли!", "Студент умер. Начните сначала", "ОК");
                await Navigation.PushAsync(new Menu());
            }
        }
    }
}