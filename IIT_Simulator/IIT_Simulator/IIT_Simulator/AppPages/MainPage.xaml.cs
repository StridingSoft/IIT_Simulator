using System.IO;
using Xamarin.Forms;

namespace IIT_Simulator
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnDisappearing()
        {
            File.Delete(SavingSystem.GetPathToFile());
            if (!States.GameOver())
                SavingSystem.WriteAllData(SavingSystem.GetPathToFile());
        }
    }
}
