using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator.Classes
{
    public class Cash
    {
        public int Money;
        public int Grant;
        public int Premium;
        private int fixedGrant = 1800;

        public void InitializeCash()
        {
            Money = 1500;
            Grant = fixedGrant;
            Premium = 0;
        }

        public void CalculateGrant() => Grant = Convert.ToInt32(fixedGrant * (1 - (80 - Simulator.States.Studying) * 0.01));

        public void CalculatePremium()
        {
            if (Simulator.Course.Corpus)
                Premium = (int)(Grant * 0.1);
        }

        public void CheckPerformance()
        {
            if (Simulator.States.Studying < 60)
                Grant = 0;
        }
    }
}
