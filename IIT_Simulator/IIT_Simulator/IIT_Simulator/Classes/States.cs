using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace IIT_Simulator.Classes
{
    public class States
    {
        private int satiety;
        private int sleep;
        private int happiness;
        private int studying;
        public int Satiety { get => satiety; set => satiety = Simulator.RemoveOverflowing(value); }
        public int Sleep { get => sleep; set => sleep = Simulator.RemoveOverflowing(value); }
        public int Happiness { get => happiness; set => happiness = Simulator.RemoveOverflowing(value); }
        public int Studying { get => studying; set => studying = Simulator.RemoveOverflowing(value); }

        public void InitializeStates()
        {
            Satiety = 50;
            Sleep = 50;
            Happiness = 50;
            Studying = 0;
        }

        public void CalculatePerformance()
        {
            Studying = (Simulator.Study.Programming + Simulator.Study.Linal + Simulator.Study.Math + Simulator.Study.Asm_eco) / 4;
        }

        public bool GameOver() => Satiety <= 0 || Sleep <= 0 || Happiness <= 0;
    }
}
