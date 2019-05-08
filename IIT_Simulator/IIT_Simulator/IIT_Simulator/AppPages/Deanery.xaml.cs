using IIT_Simulator.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Deanery : ContentPage
	{
		public Deanery ()
		{
			InitializeComponent ();
            Simulator.Course.RefreshCourse();
		}

        private void BtnAcceptCode_Clicked(object sender, System.EventArgs e) => CheatCodes.Cheat();

        private async void BtnLeave_Clicked(object sender, System.EventArgs e)
        {
            bool res = await DisplayAlert("Процесс отчисления", "Вы уверены, что не хотите учиться?", "Да", "Нет");
            if (res)
            {
                Simulator.Course.Expelled = true;
                await DisplayAlert("Отчислен!", "Студент забрал документы из вуза", "ОК");
                await Navigation.PushAsync(new Menu());
            }
        }

        public static void RefreshCourse()
        {
            Deanery.Group.Text = " Группа: " + Simulator.Course.Group;
            Deanery.Course.Text = " Курс: " + Simulator.Course.CourseNumber;
            Deanery.Semestr.Text = " Семестр: " + Simulator.Course.Semestr;
            if (Simulator.Course.GotHelp)
                Deanery.BtnGetHelp.IsEnabled = false;
        }

        private void BtnCorpus_Clicked(object sender, System.EventArgs e)
        {
            //рандом, от 1 до 20 - вы заплатили вступительный взнос но ничего не получилось, от 21 до 50 успех + 2000к, от 51 до 100 - ничего не произошло
            //при получении-потере денег обновлять деньги
        }

        private async void BtnGetHelp_Clicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Прибавка!","Вам начислено 10 000(руб.)","Ура!");
            Simulator.Cash.Money += 10000;
            NeedsPage.RefreshCash();
            Simulator.Course.GotHelp = true;
            BtnGetHelp.IsEnabled = false;
        }

        private void BtnTransfer_Clicked(object sender, System.EventArgs e) => Simulator.Course.ChangeSpeciality();
    }
}