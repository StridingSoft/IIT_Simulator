using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator.Classes
{
    public class Statistics
    {
        public int GameWins;
        public int GameLoses;
        public int Achievements;
        public int MoneyCount;

        public void InitializeStatistics()
        {
            MoneyCount = Simulator.Cash.Money;
        }
    }
}
