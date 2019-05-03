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

		public Exams ()
		{
			InitializeComponent();
		}

        private async void BtnProg_Clicked(object sender, EventArgs e)
        {
            UnluckyCharm();
            if (isPassed(Studies.Programming) && !unluck)
            {
                await DisplayAlert("Успех!", "Вы сдали программирование. Поздравляем", "Ура!");
                BtnProg.IsEnabled = false;
                ExamsControl.ExamsCounter++;
            }
            else if (unluck)
                Upset();
            else
                ExamNotPass();
            DaysControl.DecreaseDays();
        }

        private async void BtnLinal_Clicked(object sender, EventArgs e)
        {
            UnluckyCharm();
            if (isPassed(Studies.Linal) && !unluck)
            {
                await DisplayAlert("Успех!", "Вы сдали линейную алгебру. Поздравляем", "Ура!");
                BtnLinal.IsEnabled = false;
                ExamsControl.ExamsCounter++;
            }
            else if (unluck)
                Upset();
            else
                ExamNotPass();
            DaysControl.DecreaseDays();
        }

        private async void BtnASM_ECO_Clicked(object sender, EventArgs e)
        {
            UnluckyCharm();
            if (isPassed(Studies.Asm_eco) && !unluck)
            {
                await DisplayAlert("Успех!", "Вы сдали архитектуру вычислительных систем. Поздравляем", "Ура!");
                BtnASM_ECO.IsEnabled = false;
                ExamsControl.ExamsCounter++;
            }
            else if (unluck)
                Upset();
            else
                ExamNotPass();
            DaysControl.DecreaseDays();
        }

        private async void BtnMath_Clicked(object sender, EventArgs e)
        {
            UnluckyCharm();
            if (isPassed(Studies.Math) && !unluck)
            {
                await DisplayAlert("Успех!", "Вы сдали матанализ. Поздравляем", "Ура!");
                BtnMath.IsEnabled = false;
                ExamsControl.ExamsCounter++;
            }
            else if (unluck)
                Upset();
            else
                ExamNotPass();
            DaysControl.DecreaseDays();
        }

        private void UnluckyCharm()=> unluck = rnd.Next(0, 100) == rnd.Next(0, 100);

        private async void Upset() => await DisplayAlert("Неудача!", "Студент был пойман на списывании!", "ОК");

        private bool isPassed(int subject) => new Random().Next(0, 5) + subject >= 50;

        private async void ExamNotPass()=> await DisplayAlert("Неудача.", "Предмет не сдан!", "Стараться лучше"); 
    }
}