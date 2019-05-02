using IIT_Simulator.Classes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Exams : ContentPage
	{
		public Exams ()
		{
			InitializeComponent();
		}

        private async void BtnProg_Clicked(object sender, EventArgs e)
        {
            if (isPassed(Studies.Programming))
            {
                await DisplayAlert("Успех!", "Вы сдали программирование. Поздравляем", "Ура!");
                BtnProg.IsEnabled = false;
                ExamsControl.ExamsCounter++;
            }
            else
                ExamNotPass();
        }

        private async void BtnLinal_Clicked(object sender, EventArgs e)
        {
            if (isPassed(Studies.Linal))
            {
                await DisplayAlert("Успех!", "Вы сдали линейную алгебру. Поздравляем", "Ура!");
                BtnLinal.IsEnabled = false;
                ExamsControl.ExamsCounter++;
            }
            else
                ExamNotPass();
        }

        private async void BtnASM_ECO_Clicked(object sender, EventArgs e)
        {
            if (isPassed(Studies.Asm_eco))
            {
                await DisplayAlert("Успех!", "Вы сдали архитектуру вычислительных систем. Поздравляем", "Ура!");
                BtnASM_ECO.IsEnabled = false;
                ExamsControl.ExamsCounter++;
            }
            else
                ExamNotPass();
        }

        private async void BtnMath_Clicked(object sender, EventArgs e)
        {
            if (isPassed(Studies.Math))
            {
                await DisplayAlert("Успех!", "Вы сдали матанализ. Поздравляем", "Ура!");
                BtnMath.IsEnabled = false;
                ExamsControl.ExamsCounter++;
            }
            else
                ExamNotPass();
        }

        private bool isPassed(int subject) => new Random().Next(0, 5) + subject >= 50;

        private async void ExamNotPass()
        {
            await DisplayAlert("Неудача.", "Предмет не сдан!", "Стараться лучше");
            DaysControl.DecreaseDays();
        }
    }
}