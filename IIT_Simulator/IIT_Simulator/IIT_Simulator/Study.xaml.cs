using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Study : ContentPage
	{
		public Study ()
		{
			InitializeComponent();
            InitializeStates();
		}

        private void InitializeStates()
        {
            eatPoints.Text = Needs.EatPoints.Text;
            sleepPoints.Text = Needs.SleepPoints.Text;
            happyPoints.Text = Needs.HappyPoints.Text;
            studyPoints.Text = Needs.StudyPoints.Text;
        }
	}
}