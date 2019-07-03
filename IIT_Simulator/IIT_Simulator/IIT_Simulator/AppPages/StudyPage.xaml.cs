using IIT_Simulator.AppPages;
using IIT_Simulator.Classes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StudyPage : ContentPage
	{
        MainPage mainPage;
        NeedsPage needsPage;

        public Label lblEatPoints, lblSleepPoints, lblHappyPoints, lblStudyPoints;
        public ProgressBar pbFood, pbSleep, pbHappiness, pbStudying;
        public Label lblProgrPoints, lblLinalPoints, lblMathPoints, lblAsmEconomicsPoints, lblAsm_eco;
        public ProgressBar pbProgrPoints, pbLinalPoints, pbMathPoints, pbAsmEconomicsPoints;
        public Button btnAsm_eco;

        Random rnd = new Random();
		public StudyPage(MainPage mainPage, NeedsPage needsPage)
		{
			InitializeComponent();

            this.mainPage = mainPage;
            this.needsPage = needsPage;

            lblEatPoints = Content.FindByName<Label>("EatPoints");
            lblSleepPoints = Content.FindByName<Label>("SleepPoints");
            lblHappyPoints = Content.FindByName<Label>("HappyPoints");
            lblStudyPoints = Content.FindByName<Label>("StudyPoints");
            lblProgrPoints = Content.FindByName<Label>("ProgrPoints");
            lblLinalPoints = Content.FindByName<Label>("LinalPoints");
            lblMathPoints = Content.FindByName<Label>("MathPoints");
            lblAsmEconomicsPoints = Content.FindByName<Label>("Asm_economicsPoints");
            lblAsm_eco = Content.FindByName<Label>("Asm_economics");

            pbFood = Content.FindByName<ProgressBar>("PbFood");
            pbSleep = Content.FindByName<ProgressBar>("PbSleep");
            pbHappiness = Content.FindByName<ProgressBar>("PbHappiness");
            pbStudying = Content.FindByName<ProgressBar>("PbStudying");
            pbProgrPoints = Content.FindByName<ProgressBar>("PbProg");
            pbLinalPoints = Content.FindByName<ProgressBar>("PbLinal");
            pbMathPoints = Content.FindByName<ProgressBar>("PbMath");
            pbAsmEconomicsPoints = Content.FindByName<ProgressBar>("PbASM_ECO");
            btnAsm_eco = Content.FindByName<Button>("BtnASM_ECO");

            Refresh();
        }

        //не знаю как изменить это >:c
        private void BtnProg_Clicked(object sender, System.EventArgs e)
        {
            mainPage.AchievementsPage.GetOffset();
            Simulator.Achievements.ClicksCounter++;
            Simulator.Study.Programming += Simulator.Study.LearningPoints();
            Simulator.Study.Programming += LuckyCharm();
            Refreshing();
        }

        private void BtnLinal_Clicked(object sender, System.EventArgs e)
        {
            Simulator.Achievements.ClicksCounter++;
            Simulator.Study.Linal += Simulator.Study.LearningPoints();
            Simulator.Study.Linal += LuckyCharm();
            Refreshing();
        }

        private void BtnASM_ECO_Clicked(object sender, System.EventArgs e)
        {
            Simulator.Achievements.ClicksCounter++;
            Simulator.Study.Asm_eco += Simulator.Study.LearningPoints();
            Simulator.Study.Asm_eco += LuckyCharm();
            Refreshing();
        }

        private void BtnMath_Clicked(object sender, System.EventArgs e)
        {
            Simulator.Achievements.ClicksCounter++;
            Simulator.Study.Math += Simulator.Study.LearningPoints();
            Simulator.Study.Math += LuckyCharm();
            Refreshing();
        }

        private void Refreshing()
        {
            mainPage.AchievementsPage.CheckClicks();
            mainPage.DecreaseDays();
            needsPage.RefreshDays();
            needsPage.RefreshStates();
            needsPage.RefreshStatesPBars();
            Refresh();
            mainPage.ForceGameOverAlert();
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
            lblProgrPoints.Text = Simulator.Study.Programming + "/100";
            lblLinalPoints.Text = Simulator.Study.Linal + "/100";
            lblMathPoints.Text = Simulator.Study.Math + "/100";
            lblAsmEconomicsPoints.Text = Simulator.Study.Asm_eco + "/100";
        }

        public void RefreshProgressBars()
        {
            pbProgrPoints.Progress = Simulator.Study.Programming * 0.01;
            pbLinalPoints.Progress = Simulator.Study.Linal * 0.01;
            pbMathPoints.Progress = Simulator.Study.Math * 0.01;
            pbAsmEconomicsPoints.Progress = Simulator.Study.Asm_eco * 0.01;
        }

        public void Refresh()
        {
            RefreshStates();
            RefreshLabels();
            RefreshProgressBars();
        }

        private void CalculatePerformance()
        {
            Simulator.States.CalculatePerformance();
            needsPage.RefreshStates();
            needsPage.RefreshStatesPBars();
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
    }
}