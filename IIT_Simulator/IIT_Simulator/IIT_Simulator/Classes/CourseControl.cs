using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator.Classes
{
    public static class CourseControl
    {
        public static string Group;
        public static int Course;
        public static int Semestr;
        public static bool Expelled;

        public static void InitializeCourse()
        {
            Group = "Программная инженерия";
            Course = 1;
            Semestr = 1;
        }

        public static void RefreshCourse()
        {
            Deanery.Group.Text =" Группа: "+ Group;
            Deanery.Course.Text = " Курс: " + Course;
            Deanery.Semestr.Text = " Семестр: " + Semestr;
        }

        public static void ChangeCourse()
        {
            Semestr++;

            if (Semestr % 2 != 0)
            {
                Course++;
                Semestr = 1;
            }
            if (Course == 5)
                DaysControl.Congratulate = true;

            RefreshCourse();
        }
    }
}
