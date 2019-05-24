using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator.AppPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Winner : ContentPage
    {
        public Winner()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnDisappearing()
        {
            Environment.Exit(0);
        }
    }
}