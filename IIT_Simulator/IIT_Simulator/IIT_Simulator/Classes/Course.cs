using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator.Classes
{
    public class Course
    {
        public string Group;
        public int CourseNumber;
        public int Semestr;
        public bool Expelled;
        public bool GotHelp;
        public bool GroupChanged;
        public bool Corpus;

        public void InitializeCourse()
        {
            Group = "Программная инженерия";
            CourseNumber = 1;
            Semestr = 1;
            GotHelp = false;
            GroupChanged = false;
            Corpus = false;
        }


        public void ChangeCourse()
        {
            Semestr++;

            if (Semestr % 2 != 0)
            {
                CourseNumber++;
                Semestr = 1;
            }
            if (CourseNumber == 5)
                Simulator.Schedule.IsGraduated = true;
        }

        public void ChangeSpeciality()
        {
            GroupChanged = !GroupChanged;
            Simulator.Study.Asm_eco = 0;
        }

        public int GetChance() => new Random().Next(1, 100);
    }
}
