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

        MainPage mainPage;

        public Label lbMoney, lbGrant, lblEatPoints, lblSleepPoints, lblHappyPoints, lblStudyPoints;
        public Label lblDay, lblSessionDays, lblDaysToGrant;
        public ProgressBar pbFood, pbSleep, pbHappiness, pbStudying;

        public NeedsPage(MainPage mainPage)
        { 
            InitializeComponent();

            this.mainPage = mainPage;
            lbMoney = Content.FindByName<Label>("LbMoney");
            lbGrant = Content.FindByName<Label>("LbGrant");
            lblEatPoints = Content.FindByName<Label>("EatPoints");
            lblSleepPoints = Content.FindByName<Label>("SleepPoints");
            lblHappyPoints = Content.FindByName<Label>("HappyPoints");
            lblStudyPoints = Content.FindByName<Label>("StudyPoints");
            lblDay = Content.FindByName<Label>("LbDay");
            lblSessionDays = Content.FindByName<Label>("LbSessionDays");
            lblDaysToGrant = Content.FindByName<Label>("LbDaysToGrant");

            pbFood = Content.FindByName<ProgressBar>("PbFood");
            pbSleep = Content.FindByName<ProgressBar>("PbSleep");
            pbHappiness = Content.FindByName<ProgressBar>("PbHappiness");
            pbStudying = Content.FindByName<ProgressBar>("PbStudying");

            SavingSystem.ReadFile();
            RefreshStates();
            RefreshStatesPBars();
            RefreshDays();
            RefreshCash();
        }

        public void RefreshCash()
        {
            lbMoney.Text = "\t\t\tДеньги(руб.): " + Simulator.Cash.Money;
            lbGrant.Text = "\t\t\tСтипендия(руб.): " + Simulator.Cash.Grant;
        }

        public void RefreshStates()
        {
            lblEatPoints.Text = Simulator.States.Satiety + "/100";
            lblSleepPoints.Text = Simulator.States.Sleep + "/100";
            lblHappyPoints.Text = Simulator.States.Happiness + "/100";
            lblStudyPoints.Text = Simulator.States.Studying + "/100";
        }

        public void RefreshStatesPBars()
        {
            pbFood.Progress = Simulator.States.Satiety * 0.01;
            pbSleep.Progress = Simulator.States.Sleep * 0.01;
            pbHappiness.Progress = Simulator.States.Happiness * 0.01;
            pbStudying.Progress = Simulator.States.Studying * 0.01;

            ChangeProgressBarColor(Simulator.States.Satiety,  pbFood);
            ChangeProgressBarColor(Simulator.States.Sleep,    pbSleep);
            ChangeProgressBarColor(Simulator.States.Happiness,pbHappiness);
            ChangeProgressBarColor(Simulator.States.Studying, pbStudying);
        }

        public void RefreshDays()
        {
            lblDay.Text = "\t\t\tДень: " + Simulator.Schedule.DaysCounter;
            if (Simulator.Schedule.IsSession)
                lblSessionDays.Text = "\t\t\tДо конца сессии: " + Simulator.Schedule.Countdown;
            else
                lblSessionDays.Text = "\t\t\tДней до сессии: " + Simulator.Schedule.Countdown;
            lblDaysToGrant.Text = "\t\t\tДней до стипендии: " + Simulator.Schedule.DaysToGrant;
        }

        private static void ChangeProgressBarColor(int state, Xamarin.Forms.ProgressBar progressBar)
        {
            if (state < 40)
                progressBar.ProgressColor = Color.Red;
            else if (state < 70)
                progressBar.ProgressColor = Color.Yellow;
            else
                progressBar.ProgressColor = Color.Green;
        }

        private void btnEat_Click(object sender, EventArgs e)
        {
            if (Simulator.Cash.Money >= 100)
            {
                Simulator.States.Satiety += 20 + rnd.Next(1, 10);
                Simulator.States.Sleep -= rnd.Next(1, 7);
                Simulator.Cash.Money -= 100;
                mainPage.DecreaseDays();
                RefreshPage();
            }
            else
                ForceNoMoneyAlert();
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            Simulator.States.Sleep += 20 + rnd.Next(1, 10);
            Simulator.States.Satiety -= rnd.Next(1, 7);
            mainPage.DecreaseDays();
            RefreshPage();
        }

        private void btnEnjoy_Click(object sender, EventArgs e)
        {
            if (Simulator.Cash.Money >= 200)
            {
                Simulator.States.Happiness += 30 + rnd.Next(1, 10);
                Simulator.States.Satiety -= rnd.Next(5, 15);
                Simulator.States.Sleep -= rnd.Next(5, 15);
                Simulator.Cash.Money -= 200;
                mainPage.DecreaseDays();
                RefreshPage();
            }
            else
                ForceNoMoneyAlert();
        }

        private void RefreshPage()
        {
            RefreshStates();
            RefreshStatesPBars();
            mainPage.RefreshStates();
            mainPage.RefreshDays();
            RefreshCash();
            RefreshDays();
            mainPage.ForceGameOverAlert();
        }

        private async void ForceNoMoneyAlert() => await DisplayAlert("Недостаточно средств", "У вас закончились деньги", "ОК");
    }
}