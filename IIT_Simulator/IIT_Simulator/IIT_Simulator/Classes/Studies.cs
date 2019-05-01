using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator.Classes
{
    public static class Studies
    {
        public static int Programming;
        public static int Linal;
        public static int Math;
        public static int Asm_eco;

        public static void RefreshStates()
        {
            CalculatePerformance();
            Study.EatPoints.Text = Needs.EatPoints.Text;
            Study.SleepPoints.Text = Needs.SleepPoints.Text;
            Study.HappyPoints.Text = Needs.HappyPoints.Text;
            Study.StudyPoints.Text = Needs.StudyPoints.Text;

            Study.PbFood.Progress = Needs.PbFood.Progress;
            Study.PbSleep.Progress = Needs.PbSleep.Progress;
            Study.PbStudying.Progress = Needs.PbStudying.Progress;
            Study.PbHappiness.Progress = Needs.PbHappiness.Progress;

            Study.PbFood.ProgressColor = Needs.PbFood.ProgressColor;
            Study.PbStudying.ProgressColor = Needs.PbStudying.ProgressColor;
            Study.PbSleep.ProgressColor = Needs.PbSleep.ProgressColor;
            Study.PbHappiness.ProgressColor = Needs.PbHappiness.ProgressColor;
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
