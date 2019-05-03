using IIT_Simulator.AppPages;
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
		public Study()
		{
			InitializeComponent();
            Studies.Refresh();
        }

        private void BtnProg_Clicked(object sender, System.EventArgs e)
        {
            Studies.Programming += LearningPoints();
            Studies.Programming += LuckyCharm();
            Refreshing();
        }

        private void BtnLinal_Clicked(object sender, System.EventArgs e)
        {
            Studies.Linal += LearningPoints();
            Studies.Linal += LuckyCharm();
            Refreshing();
        }

        private void BtnASM_ECO_Clicked(object sender, System.EventArgs e)
        {
            Studies.Asm_eco += LearningPoints();
            Studies.Asm_eco += LuckyCharm();
            Refreshing();
        }

        private void BtnMath_Clicked(object sender, System.EventArgs e)
        {
            Studies.Math += LearningPoints();
            Studies.Math += LuckyCharm();
            Refreshing();
        }

        private int LearningPoints()
        {
            States.Satiety -= rnd.Next(5,13) + (int)(0.1 * States.Studying);
            States.Sleep -= rnd.Next(5, 13) + (int)(0.1 * States.Studying);
            States.Happiness -= rnd.Next(5, 13) + (int)(0.1 * States.Studying);
            return new Random().Next(1, 8);
        }

        private void Refreshing()
        {
            DaysControl.DecreaseDays();
            DaysControl.RefreshDays();
            States.RefreshLabels();
            States.RefreshProgressBars();
            Studies.Refresh();
            ForceGameOverAlert();
        }

        private int LuckyCharm()
        {
            if (rnd.Next(1, 100) == rnd.Next(1, 100))
            {
                Congrat();
                return 100;
            }
            else return 0;
        }

        private async void Congrat() => await DisplayAlert("Везунчик!", "Ты был удостоен автомата. Поздравляем!", "Ура!");

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
            else if (DaysControl.Congratulate)
            {
                await DisplayAlert("Выпускной!", "Ваш студент только что закончил унивеститет!", "Получить диплом");
                await Navigation.PushAsync(new Winner());
            }
        }
    }
}