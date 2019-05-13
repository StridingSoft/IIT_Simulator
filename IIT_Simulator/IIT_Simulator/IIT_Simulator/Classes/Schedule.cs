using IIT_Simulator.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator
{
    public class Schedule
    {
        public int DaysCounter;
        public int Countdown;
        public bool IsSession;
        public int DaysToGrant;
        public bool IsDeducted;
        public bool IsGraduated;

        public void InitializeDays()
        {
            DaysCounter = 1;
            Countdown = 150;
            IsSession = false;
            DaysToGrant = 30;
        }
    }
}
