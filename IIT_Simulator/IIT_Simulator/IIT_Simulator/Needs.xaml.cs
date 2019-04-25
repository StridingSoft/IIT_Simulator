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
            DecreaseDays();
            satiety = IncreaseParams(satiety, pbFood, eatPoints);
            sleep = DecreaseParams(sleep, pbSleep, sleepPoints);
            happiness += rnd.Next(5, 10);
            currentDay++;
            RefreshLabels();
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            DecreaseDays();
            sleep = IncreaseParams(sleep, pbSleep, sleepPoints);
            satiety = DecreaseParams(satiety, pbFood, eatPoints);
            happiness += rnd.Next(5,10);
            currentDay++;
            RefreshLabels();
        }
//в коде нихуя не работает, дома разберешься. Переписать это говно нахуй заново

        private int IncreaseParams(int state, ProgressBar pb, Label label)
        {
            state += 60 + rnd.Next(1,10);
            if (state > 100)
                state = 100;
            if (state < 40)
                pb.ProgressColor = Color.Red;
            else if (state < 75)
                pb.ProgressColor = Color.Yellow;
            else
                pb.ProgressColor = Color.Green;
            pb.Progress = state / 100.0;
            return state;
        }

        private int DecreaseParams(int state, ProgressBar pb, Label label)
        {
            state -= 5;
            if (state < 0)
                state = 0;
            if (state < 40)
                pb.ProgressColor = Color.Red;
            else if (state < 75)
                pb.ProgressColor = Color.Yellow;
            else
                pb.ProgressColor = Color.Green;
            pb.Progress = state / 100.0;
            return state;
        }

        private void RefreshLabels()
        {
            eatPoints.Text = satiety + "/100";
            sleepPoints.Text = sleep + "/100";
            happyPoints.Text = happiness + "/100";
            studyPoints.Text = study + "/100";
            lbDay.Text = "\t\t\tДень: " + currentDay;
            if (!semestr)
                lbDay.Text += "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tДо конца сессии: " + sessionDays;
            else
                lbDay.Text += "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tДней до сессии: " + daysToSession;
            lbMoney.Text = "\t\t\tДеньги: " + money;
            lbGrant.Text = "\t\t\tСтипендия: " + grant + "\t\t\t\t\t\tДней до стипендии: " + daysToGrant;
        }

        private void DecreaseDays() //пофиксить, нихуя не работает
        {
            if (semestr & daysToSession != 1)
                daysToSession--;
            else if (sessionDays != 1 & !semestr)
                sessionDays--;
            else if (daysToSession == 1)
            {
                semestr = false;
                sessionDays = 30;
            }
            else
            {
                semestr = true;
                daysToSession = 15;
            }
        }

        private void btnEnjoy_Click(object sender, EventArgs e)
        {

        }
    }
}