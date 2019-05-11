using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace IIT_Simulator.Classes
{
    public static class States
    {
        private static int satiety;
        private static int sleep;
        private static int happiness;
        private static int studying;

        public static int Satiety { get => satiety; set => satiety = RemoveOverflowing(value); }
        public static int Sleep { get => sleep; set => sleep = RemoveOverflowing(value); }
        public static int Happiness { get => happiness; set => happiness = RemoveOverflowing(value); }
        public static int Studying { get => studying; set => studying = RemoveOverflowing(value); }

        public static void InitializeStates()
        {
            Satiety = 50;
            Sleep = 50;
            Happiness = 50;
            Studying = 0;
        }        
        
        private static int RemoveOverflowing(int state)
        {
            if (state >= 100)
                state = 100;
            return state;
        }

        public static void CalculatePerformance()
        {
            Studying = (Studies.Programming + Studies.Linal + Studies.Math + Studies.Asm_eco) / 4;
        }

        public static bool GameOver() => Satiety <= 0 || Sleep <= 0 || Happiness <= 0;
    }
}
