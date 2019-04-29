using System;
using System.Collections.Generic;
using System.Text;

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
            RemoveOverflow();
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

        private static void RemoveOverflow()
        {
            if (Satiety > 100)
                Satiety = 100;
            if (Sleep > 100)
                Sleep = 100;
            if (Happiness > 100)
                Happiness = 100;
            if (Study > 100)
                Study = 0;
        }

        public static bool GameOver() => Satiety == 0 || Sleep == 0 || Happiness == 0;
    }
}
