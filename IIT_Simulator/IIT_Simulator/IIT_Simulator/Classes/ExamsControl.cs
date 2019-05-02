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

        private static bool CouldPassExams() => DaysControl.Session;

        public static void DeactivateButtons()
        {
            if (!CouldPassExams())
            {
                Exams.BtnProg.IsEnabled = false;
                Exams.BtnASM_ECO.IsEnabled = false;
                Exams.BtnLinal.IsEnabled = false;
                Exams.BtnMath.IsEnabled = false;
            }
        }

        public static void ActivateButtons()
        {
            if (CouldPassExams())
            {
                Exams.BtnProg.IsEnabled = true;
                Exams.BtnASM_ECO.IsEnabled = true;
                Exams.BtnLinal.IsEnabled = true;
                Exams.BtnMath.IsEnabled = true;
            }
        }
    }
}
