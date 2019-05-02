using IIT_Simulator.Classes;
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
            if (!States.GameOver() && !DaysControl.Deducted && !DaysControl.Congratulate && !CourseControl.Expelled)
                SavingSystem.WriteAllData(SavingSystem.GetPathToFile()); 
        }
    }
}
