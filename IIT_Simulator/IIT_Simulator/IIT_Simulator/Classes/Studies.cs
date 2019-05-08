using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator.Classes
{
    public static class Studies
    {
        public static int Programming { get; set; }
        public static int Linal { get; set; }
        public static int Math { get; set; }
        public static int Asm_eco { get; set; }

        public static void InitializeSubjects()
        {
            Programming = 0;
            Linal = 0;
            Math = 0;
            Asm_eco = 0;
        }

        public static void RefreshStates()
        {
            CalculatePerformance();
            Study.EatPoints.Text = NeedsPage.EatPoints.Text;
            Study.SleepPoints.Text = NeedsPage.SleepPoints.Text;
            Study.HappyPoints.Text = NeedsPage.HappyPoints.Text;
            Study.StudyPoints.Text = NeedsPage.StudyPoints.Text;

            Study.PbFood.Progress = NeedsPage.PbFood.Progress;
            Study.PbSleep.Progress = NeedsPage.PbSleep.Progress;
            Study.PbStudying.Progress = NeedsPage.PbStudying.Progress;
            Study.PbHappiness.Progress = NeedsPage.PbHappiness.Progress;

            Study.PbFood.ProgressColor = NeedsPage.PbFood.ProgressColor;
            Study.PbStudying.ProgressColor = NeedsPage.PbStudying.ProgressColor;
            Study.PbSleep.ProgressColor = NeedsPage.PbSleep.ProgressColor;
            Study.PbHappiness.ProgressColor = NeedsPage.PbHappiness.ProgressColor;
        }

        public static void RefreshLabels() 
        {
            Programming = RemoveOverflowing(Programming);
            Linal = RemoveOverflowing(Linal);
            Math = RemoveOverflowing(Math);
            Asm_eco = RemoveOverflowing(Asm_eco);

            Study.ProgrPoints.Text = Programming + "/100";
            Study.LinalPoints.Text = Linal + "/100";
            Study.MathPoints.Text = Math + "/100";
            Study.Asm_economicsPoints.Text = Asm_eco + "/100";
        }

        public static void RefreshProgressBars()
        {
            Study.PbProg.Progress = Programming * 0.01;
            Study.PbLinal.Progress = Linal * 0.01;
            Study.PbMath.Progress = Math * 0.01;
            Study.PbASM_ECO.Progress = Asm_eco * 0.01;
        }

        public static void Refresh()
        {
            RefreshStates();
            RefreshLabels();
            RefreshProgressBars();
        }

        private static void CalculatePerformance()
        {
            States.Studying = (Programming + Linal + Math + Asm_eco) / 4;
            States.RefreshLabels();
            States.RefreshProgressBars();
        }

        private static int RemoveOverflowing(int state)
        {
            if (state >= 100)
                state = 100;
            return state;
        }


    }
}
