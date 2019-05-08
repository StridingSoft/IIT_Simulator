using IIT_Simulator.Classes;
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
        public static bool Deducted;
        public static bool Congratulate;

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
                if (States.Studying < 50 || ExamsControl.ExamsCounter < 4)
                    Deducted = true;
                
                Session = !Session;
                Countdown = 150;

                Simulator.Cash.CalculateGrant();
                Simulator.Cash.CheckPerformance();

                ExamsControl.ExamsCounter = 0;

                Studies.InitializeSubjects();
                Studies.Refresh();

                ExamsControl.DeactivateButtons();

                Simulator.Course.ChangeCourse();
            }
            else if (Countdown == 0 && !Session)
            {
                Session = !Session;
                Countdown = 30;
                ExamsControl.ActivateButtons();
            }
            if (DaysToGrant == 0)
            {
                Simulator.Cash.Money += Simulator.Cash.Grant;
                DaysToGrant = 30;
                States.RefreshLabels();
                NeedsPage.RefreshCash();
            }
            RefreshDays();
        }

        public static void RefreshDays()
        {
            NeedsPage.LbDay.Text = "\t\t\tДень: " + DaysCounter;
            if (Session)
                NeedsPage.LbSessionDays.Text = "\t\t\tДо конца сессии: " + Countdown;
            else
                NeedsPage.LbSessionDays.Text = "\t\t\tДней до сессии: " + Countdown;
            NeedsPage.LbDaysToGrant.Text = "\t\t\tДней до стипендии: " + DaysToGrant;
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
