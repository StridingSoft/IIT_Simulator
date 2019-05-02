using IIT_Simulator.Classes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Study : ContentPage
	{
        Random rnd = new Random();
		public Study ()
		{
			InitializeComponent();
            Studies.RefreshStates();
            Studies.RefreshLabels();
            Studies.RefreshProgressBars();
        }

        private void BtnProg_Clicked(object sender, System.EventArgs e)
        {
            Studies.Programming = ChangeStats(Studies.Programming);
            Refreshing();
        }

        private void BtnLinal_Clicked(object sender, System.EventArgs e)
        {
            Studies.Linal = ChangeStats(Studies.Linal);
            Refreshing();
        }

        private void BtnASM_ECO_Clicked(object sender, System.EventArgs e)
        {
            Studies.Asm_eco = ChangeStats(Studies.Asm_eco);
            Refreshing();
        }

        private void BtnMath_Clicked(object sender, System.EventArgs e)
        {
            Studies.Math = ChangeStats(Studies.Math);
            Refreshing();
        }

        private int ChangeStats(int subject)
        {
            States.Satiety -= rnd.Next(5,13) + (int)(0.1 * subject);
            States.Sleep -= rnd.Next(5, 13) + (int)(0.1 * subject);
            States.Happiness -= rnd.Next(5, 13) + (int)(0.1 * subject);

            subject += new Random().Next(1, 7);
            return subject;
        }

        private void Refreshing()
        {
            IncreaseDays();
            DaysControl.ChangePeriodIfNeeded();
            States.RefreshLabels();
            States.RefreshProgressBars();
            Studies.RefreshLabels();
            Studies.RefreshProgressBars();
            Studies.RefreshStates();
            ForceGameOverAlert();
        }

        private void IncreaseDays()
        {
            DaysControl.Countdown--;
            DaysControl.DaysCounter++;
            DaysControl.DaysToGrant--;
        }

        private async void ForceGameOverAlert()
        {
            if (States.GameOver())
            {
                await DisplayAlert("Вы проиграли!", "Студент умер. Начните сначала", "ОК");
                await Navigation.PushAsync(new Menu());
            }
            else if (DaysControl.Deducted)
            {
                await DisplayAlert("Неуспеваемость!", "Студент был отчислен. Начните сначала", "ОК");
                await Navigation.PushAsync(new Menu());
            }
        }
    }
}