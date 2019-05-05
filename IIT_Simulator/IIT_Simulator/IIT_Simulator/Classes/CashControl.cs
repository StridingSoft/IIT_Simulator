using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator
{
    public static class CashControl
    {
        public static int Money;
        public static int Grant;
        private static int fixedGrant = 1800;

        public static void InitializeCash()
        {
            Money = 1500;
            Grant = fixedGrant;
        }

        public static void RefreshCash()
        {
            Needs.LbMoney.Text = "\t\t\tДеньги(руб.): " + Money;
            Needs.LbGrant.Text = "\t\t\tСтипендия(руб.): " + Grant;
        }

        public static void CalculateGrant()=> Grant = Convert.ToInt32(fixedGrant * (1 - (80 - States.Studying) * 0.01));

        public static void CheckPerformance()
        {
            if (States.Studying < 60)
                Grant = 0;
        }
    }
}
