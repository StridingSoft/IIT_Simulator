using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator.Classes
{
    public class Achievements
    {
        public int ClicksCounter;
        public int TransferCounter;
        public int ProgExCounter;
        public bool Uncorrupt;
        public bool Unnoticed;
        public bool Suicide;
        public bool Corpus;
        public bool OnEdge;

        public void InitializeAchievements()
        {
            ClicksCounter = 0;
            TransferCounter = 0;
            Unnoticed = false;
            Suicide = false;
            Corpus = false;
        }

        public void CheckProgrammingPoints()
        {
            if (Simulator.Study.Programming >= 90)
                ProgExCounter++;
        }
    }
}
