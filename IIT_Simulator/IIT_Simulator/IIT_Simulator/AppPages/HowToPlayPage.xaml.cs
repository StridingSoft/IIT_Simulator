using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HowToPlayPage : ContentPage
	{
		public HowToPlayPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}