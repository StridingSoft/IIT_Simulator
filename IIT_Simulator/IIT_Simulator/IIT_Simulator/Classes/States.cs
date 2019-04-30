using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace IIT_Simulator
{
    public static class States
    {
        public static int Satiety { get; set; }
        public static int Sleep { get; set; }
        public static int Happiness { get; set; }
        public static int Study { get; set; }

        public static void InitializeStates()
        {
            Satiety = 50;
            Sleep = 50;
            Happiness = 50;
            Study = 0;
        }

        public static void RefreshLabels()
        {
            RemoveOverflow(Satiety);
            RemoveOverflow(Sleep);
            RemoveOverflow(Happiness);
            RemoveOverflow(Study);

            Needs.EatPoints.Text = Satiety + "/100";
            Needs.SleepPoints.Text = Sleep + "/100";
            Needs.HappyPoints.Text = Happiness + "/100";
            Needs.StudyPoints.Text = Study + "/100";
            Needs.LbDay.Text = "\t\t\tДень: " + DaysControl.DaysCounter;
            if (DaysControl.Session)
                Needs.LbSessionDays.Text = "\t\t\tДо конца сессии: " + DaysControl.Countdown;
            else
                Needs.LbSessionDays.Text = "\t\t\tДней до сессии: " + DaysControl.Countdown;
            Needs.LbMoney.Text = "\t\t\tДеньги(руб.): " + CashControl.Money;
            Needs.LbGrant.Text = "\t\t\tСтипендия(руб.): " + CashControl.Grant;
            Needs.LbDaysToGrant.Text = "\t\t\tДней до стипендии: " + DaysControl.DaysToGrant;
        }

        public static void RefreshProgressBars()
        {
            Needs.PbFood.Progress = Satiety * 0.01;
            Needs.PbSleep.Progress = Sleep * 0.01;
            Needs.PbHappiness.Progress = Happiness *0.01;
            Needs.PbStudying.Progress = Study * 0.01;

            ChangeProgressBarColor(Satiety, Needs.PbFood);
            ChangeProgressBarColor(Sleep, Needs.PbSleep);
            ChangeProgressBarColor(Happiness, Needs.PbHappiness);
            ChangeProgressBarColor(Study, Needs.PbStudying);
        }

        private static void ChangeProgressBarColor(int state, Xamarin.Forms.ProgressBar progressBar)
        {
            if (state < 40)
                progressBar.ProgressColor = Color.Red;
            else if (state < 70)
                progressBar.ProgressColor = Color.Yellow;
            else
                progressBar.ProgressColor = Color.Green;

        }

        private static void RemoveOverflow(int state)
        {
            if (state > 100)
                state = 100;
        }

        public static bool GameOver() => Satiety <= 0 || Sleep <= 0 || Happiness <= 0;
    }
}
