using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Needs : ContentPage
    {
        Random rnd = new Random();
        int satiety = 50;
        int sleep = 50;
        int happiness = 50;
        int study = 0;
        int money = 2800;
        int currentDay = 1;
        int daysToSession = 15;
        int sessionDays = 30;
        bool semestr = true;
        int grant = 2800;
        int daysToGrant = 30;

        public Needs()
        {
            InitializeComponent();
            RefreshLabels();
        }

        private void btnEat_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {


        }

        private void RefreshLabels()
        {
            eatPoints.Text = satiety + "/100";
            sleepPoints.Text = sleep + "/100";
            happyPoints.Text = happiness + "/100";
            studyPoints.Text = study + "/100";
            lbDay.Text = "\t\t\tДень: " + currentDay;
            if (!semestr)
                lbSessionDays.Text = "\t\t\tДо конца сессии: " + sessionDays;
            else
                lbSessionDays.Text = "\t\t\tДней до сессии: " + daysToSession;
            lbMoney.Text = "\t\t\tДеньги(руб.): " + money;
            lbGrant.Text = "\t\t\tСтипендия(руб.): " + grant;
            lbDaysToGrant.Text = "\t\t\tДней до стипендии: " + daysToGrant;
        }


        private void btnEnjoy_Click(object sender, EventArgs e)
        {

        }
    }
}