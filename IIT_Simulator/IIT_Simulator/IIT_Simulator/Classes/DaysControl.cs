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
    }
}
