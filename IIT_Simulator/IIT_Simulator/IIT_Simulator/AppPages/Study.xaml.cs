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
        MainPage mainPage;
        NeedsPage needsPage;

        public Label lblEatPoints, lblSleepPoints, lblHappyPoints, lblStudyPoints;
        public ProgressBar pbFood, pbSleep, pbHappiness, pbStudying;
        public Label lblProgrPoints, lblLinalPoints, lblMathPoints, lblAsmEconomicsPoints;
        public ProgressBar pbProgrPoints, pbLinalPoints, pbMathPoints, pbAsmEconomicsPoints;

        Random rnd = new Random();
		public Study(MainPage mainPage, NeedsPage needsPage)
		{
			InitializeComponent();

            this.mainPage = mainPage;
            this.needsPage = needsPage;

            lblEatPoints = this.Content.FindByName<Label>("EatPoints");
            lblSleepPoints = this.Content.FindByName<Label>("SleepPoints");
            lblHappyPoints = this.Content.FindByName<Label>("HappyPoints");
            lblStudyPoints = this.Content.FindByName<Label>("StudyPoints");
            lblProgrPoints = this.Content.FindByName<Label>("ProgrPoints");
            lblLinalPoints = this.Content.FindByName<Label>("LinalPoints");
            lblMathPoints = this.Content.FindByName<Label>("MathPoints");
            lblAsmEconomicsPoints = this.Content.FindByName<Label>("Asm_economicsPoints");

            pbFood = this.Content.FindByName<ProgressBar>("PbFood");
            pbSleep = this.Content.FindByName<ProgressBar>("PbSleep");
            pbHappiness = this.Content.FindByName<ProgressBar>("PbHappiness");
            pbStudying = this.Content.FindByName<ProgressBar>("PbStudying");
            pbProgrPoints = this.Content.FindByName<ProgressBar>("PbProg");
            pbLinalPoints = this.Content.FindByName<ProgressBar>("PbLinal");
            pbMathPoints = this.Content.FindByName<ProgressBar>("PbMath");
            pbAsmEconomicsPoints = this.Content.FindByName<ProgressBar>("PbASM_ECO");

            Refresh();
        }

        private void BtnProg_Clicked(object sender, System.EventArgs e)
        {
            Studies.Programming += Studies.LearningPoints();
            Studies.Programming += LuckyCharm();
            Refreshing();
        }

        private void BtnLinal_Clicked(object sender, System.EventArgs e)
        {
            Studies.Linal += Studies.LearningPoints();
            Studies.Linal += LuckyCharm();
            Refreshing();
        }

        private void BtnASM_ECO_Clicked(object sender, System.EventArgs e)
        {
            Studies.Asm_eco += Studies.LearningPoints();
            Studies.Asm_eco += LuckyCharm();
            Refreshing();
        }

        private void BtnMath_Clicked(object sender, System.EventArgs e)
        {
            Studies.Math += Studies.LearningPoints();
            Studies.Math += LuckyCharm();
            Refreshing();
        }

        private void Refreshing()
        {
            mainPage.DecreaseDays();
            needsPage.RefreshDays();
            needsPage.RefreshLabels();
            needsPage.RefreshProgressBars();
            Refresh();
            ForceGameOverAlert();
        }

        public void RefreshStates()
        {
            CalculatePerformance();
            lblEatPoints.Text = needsPage.lblEatPoints.Text;
            lblSleepPoints.Text = needsPage.lblSleepPoints.Text;
            lblHappyPoints.Text = needsPage.lblHappyPoints.Text;
            lblStudyPoints.Text = needsPage.lblStudyPoints.Text;

            pbFood.Progress = needsPage.pbFood.Progress;
            pbSleep.Progress = needsPage.pbSleep.Progress;
            pbStudying.Progress = needsPage.pbStudying.Progress;
            pbHappiness.Progress = needsPage.pbHappiness.Progress;

            pbFood.ProgressColor = needsPage.pbFood.ProgressColor;
            pbStudying.ProgressColor = needsPage.pbStudying.ProgressColor;
            pbSleep.ProgressColor = needsPage.pbSleep.ProgressColor;
            pbHappiness.ProgressColor = needsPage.pbHappiness.ProgressColor;
        }

        public void RefreshLabels()
        {
            lblProgrPoints.Text = Studies.Programming + "/100";
            lblLinalPoints.Text = Studies.Linal + "/100";
            lblMathPoints.Text = Studies.Math + "/100";
            lblAsmEconomicsPoints.Text = Studies.Asm_eco + "/100";
        }

        public void RefreshProgressBars()
        {
            pbProgrPoints.Progress = Studies.Programming * 0.01;
            pbLinalPoints.Progress = Studies.Linal * 0.01;
            pbMathPoints.Progress = Studies.Math * 0.01;
            pbAsmEconomicsPoints.Progress = Studies.Asm_eco * 0.01;
        }

        public void Refresh()
        {
            RefreshStates();
            RefreshLabels();
            RefreshProgressBars();
        }

        private void CalculatePerformance()
        {
            States.CalculatePerformance();
            needsPage.RefreshLabels();
            needsPage.RefreshProgressBars();
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
                await DisplayAlert("Выпускной!", "Ваш студент только что закончил университет!", "Получить диплом");
                await Navigation.PushAsync(new Winner());
            }
        }
    }
}