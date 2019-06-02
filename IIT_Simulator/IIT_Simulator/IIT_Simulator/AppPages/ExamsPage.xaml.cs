using IIT_Simulator.Classes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExamsPage : ContentPage
	{
        Random rnd = new Random();
        bool unluck;

        MainPage mainPage;

        Button btnProg, btnASM_ECO, btnLinal, btnMath;
        public Label lblAsm_eco;

		public ExamsPage(MainPage mainPage)
		{
			InitializeComponent();

            this.mainPage = mainPage;

            lblAsm_eco = Asm_economics;

            btnProg = Content.FindByName<Button>("BtnProg");
            btnASM_ECO = Content.FindByName<Button>("BtnASM_ECO");
            btnLinal = Content.FindByName<Button>("BtnLinal");
            btnMath = Content.FindByName<Button>("BtnMath");
        }

        public void DeactivateButtons()
        {
            if (!Simulator.Session.CouldPassExams())
            {
                btnProg.IsEnabled = false;
                btnASM_ECO.IsEnabled = false;
                btnLinal.IsEnabled = false;
                btnMath.IsEnabled = false;
            }
        }

        public void ActivateButtons()
        {
            if (Simulator.Session.CouldPassExams())
            {
                btnProg.IsEnabled = true;
                btnASM_ECO.IsEnabled = true;
                btnLinal.IsEnabled = true;
                btnMath.IsEnabled = true;
            }
        }

        private void BtnProg_Clicked(object sender, EventArgs e)
        {
            Simulator.Achievements.CheckProgrammingPoints();
            mainPage.AchievementsPage.CheckProgramming();
            PassExamsMessage("программирование", Simulator.Study.Programming, btnProg);
        }
        
        private void BtnLinal_Clicked(object sender, EventArgs e) => PassExamsMessage("линейную алгебру", Simulator.Study.Linal, btnLinal);

        private void BtnASM_ECO_Clicked(object sender, EventArgs e) => PassExamsMessage("архитектуру вычислительных систем", Simulator.Study.Asm_eco, btnASM_ECO);

        private void BtnMath_Clicked(object sender, EventArgs e) =>  PassExamsMessage("матанализ",Simulator.Study.Math, btnMath);
        
        private async void PassExamsMessage(string text, int subj, Button btn)
        {
            UnluckyCharm();
            if (IsPassed(subj) && !unluck)
            {
                await DisplayAlert("Успех!", $"Вы сдали {text}. Поздравляем", "Ура!");
                btn.IsEnabled = false;
                Simulator.Session.ExamsCounter++;
            }
            else if (unluck)
            {
                Upset();
                Simulator.Achievements.Unnoticed = true;
                mainPage.AchievementsPage.CheckUnluck();
            }
            else
                ExamNotPass();
            mainPage.DecreaseDays();
        }

        private void UnluckyCharm()=> unluck = rnd.Next(0, 50) == rnd.Next(0, 50);

        private async void Upset() => await DisplayAlert("Неудача!", "Студент был пойман на списывании!", "ОК");

        private bool IsPassed(int subject) => new Random().Next(0, 5) + subject >= 50;

        private async void ExamNotPass()=> await DisplayAlert("Неудача.", "Предмет не сдан!", "Стараться лучше"); 
    }
}