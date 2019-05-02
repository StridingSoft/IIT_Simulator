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

        private void BtnAcceptCode_Clicked(object sender, System.EventArgs e)=>CheatCodes.Cheat();

        private async void BtnLeave_Clicked(object sender, System.EventArgs e)
        {
            CourseControl.Expelled = true;
            await DisplayAlert("Отчислен!", "Студент забрал документы из вуза", "ОК");
            await Navigation.PushAsync(new Menu());
        }

        private void BtnCorpus_Clicked(object sender, System.EventArgs e)
        {

        }

        private void BtnGetHelp_Clicked(object sender, System.EventArgs e)
        {

        }

        private void BtnTransfer_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}