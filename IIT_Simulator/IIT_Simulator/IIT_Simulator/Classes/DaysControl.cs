using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator
{
    public static class DaysControl
    {
        public static int DaysCounter;
        public static int Countdown;
        public static bool Session;
        public static int DaysToGrant;

        public static void InitializeDays()
        {
            DaysCounter = 1;
            Countdown = 150;
            Session = false;
            DaysToGrant = 30;
        }

        public static void ChangePeriodIfNeeded()
        {
            if (Countdown == 0 && Session)
            {
                Session = !Session;
                Countdown = 150;
            }
            else if (Countdown == 0 && !Session)
            {
                Session = !Session;
                Countdown = 30;
            }
            if (DaysToGrant == 0)
            {
                CashControl.Money += CashControl.Grant;
                DaysToGrant = 30;
                States.RefreshLabels();
            }
        }

        public static void DecreaseDays()
        {
            DaysCounter++;
            Countdown--;
            DaysToGrant--;
            ChangePeriodIfNeeded();
        }
    }
}
