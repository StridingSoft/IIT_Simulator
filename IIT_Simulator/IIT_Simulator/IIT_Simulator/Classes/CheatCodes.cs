using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator.Classes
{
    public static class CheatCodes
    {
        private static string maxNeeds = "maxmotives";
        private static string maxPerformance = "maxstudy";
        private static string addMoney = "motherlode";
        private static string upToCourse = "fourcourse";

        public static void Cheat()
        {
            if (Deanery.CheatCode.Text == maxNeeds)
            {
                States.Satiety = 100;
                States.Sleep = 100;
                States.Happiness = 100;

            }
            else if (Deanery.CheatCode.Text == maxPerformance)
            {
                Studies.Programming = 100;
                Studies.Linal = 100;
                Studies.Asm_eco = 100;
                Studies.Math = 100;
            }
            else if (Deanery.CheatCode.Text == addMoney)
                CashControl.Money += 5000;
            else if (Deanery.CheatCode.Text == upToCourse)
                CourseControl.Course = 4;

            States.RefreshLabels();
            States.RefreshProgressBars();
            Studies.Refresh();
            CashControl.RefreshCash();
            CourseControl.RefreshCourse();
            Deanery.CheatCode.Text = "";
        }
    }
}
