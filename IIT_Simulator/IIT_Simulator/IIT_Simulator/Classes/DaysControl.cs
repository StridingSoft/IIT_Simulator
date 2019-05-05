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

                CashControl.CalculateGrant();
                CashControl.CheckPerformance();

                ExamsControl.ExamsCounter = 0;

                Studies.InitializeSubjects();
                Studies.Refresh();

                ExamsControl.DeactivateButtons();

                CourseControl.ChangeCourse();
            }
            else if (Countdown == 0 && !Session)
            {
                Session = !Session;
                Countdown = 30;
                ExamsControl.ActivateButtons();
            }
            if (DaysToGrant == 0)
            {
                CashControl.Money += CashControl.Grant;
                DaysToGrant = 30;
                States.RefreshLabels();
                CashControl.RefreshCash();
            }
            RefreshDays();
        }

        public static void RefreshDays()
        {
            Needs.LbDay.Text = "\t\t\tДень: " + DaysCounter;
            if (Session)
                Needs.LbSessionDays.Text = "\t\t\tДо конца сессии: " + Countdown;
            else
                Needs.LbSessionDays.Text = "\t\t\tДней до сессии: " + Countdown;
            Needs.LbDaysToGrant.Text = "\t\t\tДней до стипендии: " + DaysToGrant;
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
