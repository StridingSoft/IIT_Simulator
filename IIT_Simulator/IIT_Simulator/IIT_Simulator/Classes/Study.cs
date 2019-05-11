using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator.Classes
{
    public class Study
    {
        public int programming;
        public int linal;
        public int math;
        public int asm_eco;

        public int Programming { get { return programming; } set { programming = RemoveOverflowing(value); } }
        public int Linal { get { return programming; } set { programming = RemoveOverflowing(value); } }
        public int Math { get { return programming; } set { programming = RemoveOverflowing(value); } }
        public int Asm_eco { get { return programming; } set { programming = RemoveOverflowing(value); } }

        private Random rnd = new Random();
        public void InitializeSubjects()
        {
            Programming = 0;
            Linal = 0;
            Math = 0;
            Asm_eco = 0;
        }

        private int RemoveOverflowing(int state)
        {
            if (state >= 100)
                state = 100;
            return state;
        }

        public int LearningPoints()
        {
            Simulator.States.Satiety -= rnd.Next(5, 13) + (int)(0.1 * Simulator.States.Studying);
            Simulator.States.Sleep -= rnd.Next(5, 13) + (int)(0.1 * Simulator.States.Studying);
            Simulator.States.Happiness -= rnd.Next(5, 13) + (int)(0.1 * Simulator.States.Studying);
            return new Random().Next(1, 8);
        }

    }
}
