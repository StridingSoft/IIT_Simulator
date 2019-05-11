using IIT_Simulator.Classes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Exams : ContentPage
	{
        Random rnd = new Random();
        bool unluck;

        MainPage mainPage;

        Button btnProg, btnASM_ECO, btnLinal, btnMath;

		public Exams(MainPage mainPage)
		{
			InitializeComponent();

            this.mainPage = mainPage;

            btnProg = this.Content.FindByName<Button>("BtnProg");
            btnASM_ECO = this.Content.FindByName<Button>("BtnASM_ECO");
            btnLinal = this.Content.FindByName<Button>("BtnLinal");
            btnMath = this.Content.FindByName<Button>("BtnMath");
        }

        public void DeactivateButtons()
        {
            if (!ExamsControl.CouldPassExams())
            {
                btnProg.IsEnabled = false;
                btnASM_ECO.IsEnabled = false;
                btnLinal.IsEnabled = false;
                btnMath.IsEnabled = false;
            }
        }

        public void ActivateButtons()
        {
            if (ExamsControl.CouldPassExams())
            {
                btnProg.IsEnabled = true;
                btnASM_ECO.IsEnabled = true;
                btnLinal.IsEnabled = true;
                btnMath.IsEnabled = true;
            }
        }

        private async void BtnProg_Clicked(object sender, EventArgs e)
        {
            UnluckyCharm();
            if (IsPassed(Studies.Programming) && !unluck)
            {
                await DisplayAlert("Успех!", "Вы сдали программирование. Поздравляем", "Ура!");
                BtnProg.IsEnabled = false;
                ExamsControl.ExamsCounter++;
            }
            else if (unluck)
                Upset();
            else
                ExamNotPass();
            mainPage.DecreaseDays();
        }

        private async void BtnLinal_Clicked(object sender, EventArgs e)
        {
            UnluckyCharm();
            if (IsPassed(Studies.Linal) && !unluck)
            {
                await DisplayAlert("Успех!", "Вы сдали линейную алгебру. Поздравляем", "Ура!");
                BtnLinal.IsEnabled = false;
                ExamsControl.ExamsCounter++;
            }
            else if (unluck)
                Upset();
            else
                ExamNotPass();
            mainPage.DecreaseDays();
        }

        private async void BtnASM_ECO_Clicked(object sender, EventArgs e)
        {
            UnluckyCharm();
            if (IsPassed(Studies.Asm_eco) && !unluck)
            {
                await DisplayAlert("Успех!", "Вы сдали архитектуру вычислительных систем. Поздравляем", "Ура!");
                BtnASM_ECO.IsEnabled = false;
                ExamsControl.ExamsCounter++;
            }
            else if (unluck)
                Upset();
            else
                ExamNotPass();
            mainPage.DecreaseDays();
        }

        private async void BtnMath_Clicked(object sender, EventArgs e)
        {
            UnluckyCharm();
            if (IsPassed(Studies.Math) && !unluck)
            {
                await DisplayAlert("Успех!", "Вы сдали матанализ. Поздравляем", "Ура!");
                BtnMath.IsEnabled = false;
                ExamsControl.ExamsCounter++;
            }
            else if (unluck)
                Upset();
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