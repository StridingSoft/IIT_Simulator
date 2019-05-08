using IIT_Simulator.AppPages;
using IIT_Simulator.Classes;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NeedsPage : ContentPage
    {
        Random rnd = new Random();

        public NeedsPage()
        { 
            InitializeComponent();
            SavingSystem.ReadFile();
            States.RefreshLabels();
            States.RefreshProgressBars();
            DaysControl.RefreshDays();
            RefreshCash();
        }

        public static void RefreshCash()
        {
            LbMoney.Text = "\t\t\tДеньги(руб.): " + Simulator.Cash.Money;
            LbGrant.Text = "\t\t\tСтипендия(руб.): " + Simulator.Cash.Grant;
        }

        

        private void btnEat_Click(object sender, EventArgs e)
        {
            if (Simulator.Cash.Money >= 100)
            {
                States.Satiety += 20 + rnd.Next(1, 10);
                States.Sleep -= rnd.Next(1, 7);
                Simulator.Cash.Money -= 100;
                DaysControl.DecreaseDays();
                Refresh();
            }
            else
                ForceNoMoneyAlert();
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            States.Sleep += 20 + rnd.Next(1, 10);
            States.Satiety -= rnd.Next(1, 7);
            DaysControl.DecreaseDays();
            Refresh();
        }

        private void btnEnjoy_Click(object sender, EventArgs e)
        {
            if (Simulator.Cash.Money >= 200)
            {
                States.Happiness += 30 + rnd.Next(1, 10);
                States.Satiety -= rnd.Next(5, 15);
                States.Sleep -= rnd.Next(5, 15);
                Simulator.Cash.Money -= 200;
                DaysControl.DecreaseDays();
                Refresh();
            }
            else
                ForceNoMoneyAlert();
        }

        private void Refresh()
        {
            States.RefreshLabels();
            States.RefreshProgressBars();
            Studies.RefreshStates();
            DaysControl.RefreshDays();
            RefreshCash();
            ForceGameOverAlert();
        }

        private async void ForceNoMoneyAlert() => await DisplayAlert("Недостаточно средств", "У вас закончились деньги", "ОК");

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
                await DisplayAlert("Выпускной!", "Ваш студент только что закончил университет!", "Получить диплом");
                await Navigation.PushAsync(new Winner());
            }
        }
    }
}