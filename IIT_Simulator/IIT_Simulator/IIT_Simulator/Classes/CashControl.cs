using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator
{
    public static class CashControl
    {
        public static int Money;
        public static int Grant;

        public static void InitializeCash()
        {
            Money = 2000;
            Grant = 2000;
        }

        public static void CalculateGrant()=> Grant = Convert.ToInt32(Grant * (1 - (80 - States.Studying) * 0.01));
    }
}
