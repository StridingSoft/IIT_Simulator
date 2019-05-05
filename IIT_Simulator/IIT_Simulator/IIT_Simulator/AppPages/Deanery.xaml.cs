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
            CourseControl.RefreshCourse();
		}

        private void BtnAcceptCode_Clicked(object sender, System.EventArgs e) => CheatCodes.Cheat();

        private async void BtnLeave_Clicked(object sender, System.EventArgs e)
        {
            CourseControl.Expelled = true;
            await DisplayAlert("Отчислен!", "Студент забрал документы из вуза", "ОК");
            await Navigation.PushAsync(new Menu());
        }

        private void BtnCorpus_Clicked(object sender, System.EventArgs e)
        {
            //рандом, от 1 до 20 - вы заплатили вступительный взнос но ничего не получилось, от 21 до 50 успех + 2000к, от 51 до 100 - ничего не произошло
            //при получении-потере денег обновлять деньги
        }

        private void BtnGetHelp_Clicked(object sender, System.EventArgs e)
        {
                //получить помощь 10к (или меньше) раз за семестр
                //деактивировать кнопку и сохранять ее состояние
        }

        private void BtnTransfer_Clicked(object sender, System.EventArgs e)
        {
            //перевод из одной группы в другую, обнуляет предмет который меняется, возможен не более трех раз
        }
    }
}