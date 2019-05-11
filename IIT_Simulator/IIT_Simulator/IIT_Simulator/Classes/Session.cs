using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator.Classes
{
    public class Session
    {
        public int ExamsCounter;

        public void InitializeExams()
        {
            ExamsCounter = 0;
        }

        public bool CouldPassExams() => Simulator.Schedule.IsSession;
    }
}
