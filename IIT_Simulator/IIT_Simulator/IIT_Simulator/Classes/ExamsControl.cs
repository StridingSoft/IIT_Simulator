using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator.Classes
{
    public static class ExamsControl
    {
        public static int ExamsCounter;

        public static void InitializeExams()
        {
            ExamsCounter = 0;
        }

        public static bool CouldPassExams() => DaysControl.Session;
    }
}
