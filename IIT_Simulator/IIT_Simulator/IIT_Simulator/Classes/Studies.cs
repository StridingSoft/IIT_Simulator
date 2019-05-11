using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator.Classes
{
    public static class Studies
    {
        public static int programming;
        public static int linal;
        public static int math;
        public static int asm_eco;

        public static int Programming { get { return programming; } set { programming = RemoveOverflowing(value); } }
        public static int Linal { get { return programming; } set { programming = RemoveOverflowing(value); } }
        public static int Math { get { return programming; } set { programming = RemoveOverflowing(value); } }
        public static int Asm_eco { get { return programming; } set { programming = RemoveOverflowing(value); } }

        private static Random rnd = new Random();
        public static void InitializeSubjects()
        {
            Programming = 0;
            Linal = 0;
            Math = 0;
            Asm_eco = 0;
        }

        private static int RemoveOverflowing(int state)
        {
            if (state >= 100)
                state = 100;
            return state;
        }

        public static int LearningPoints()
        {
            States.Satiety -= rnd.Next(5, 13) + (int)(0.1 * States.Studying);
            States.Sleep -= rnd.Next(5, 13) + (int)(0.1 * States.Studying);
            States.Happiness -= rnd.Next(5, 13) + (int)(0.1 * States.Studying);
            return new Random().Next(1, 8);
        }

    }
}
