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
        public static bool GotHelp;

        public static void InitializeCourse()
        {
            Group = "Программная инженерия";
            Course = 1;
            Semestr = 1;
            GotHelp = false;
        }

        public static void RefreshCourse()
        {
            Deanery.Group.Text =" Группа: "+ Group;
            Deanery.Course.Text = " Курс: " + Course;
            Deanery.Semestr.Text = " Семестр: " + Semestr;
            if (GotHelp)
                Deanery.BtnGetHelp.IsEnabled = false;
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
        }

        public static void ChangeSpeciality()
        {
            //if (!BI)
            //{
            //    Group = "Бизнес информатика";
            //    Study.Asm_economics.Text = "Экономическая теория и ее разделы";
            //    Exams.Asm_economics.Text = "Экономическая теория и ее разделы";
            //    Study.BtnASM_ECO.Text = "Рассчитать доход приложения";
            //    BI = true;
            //    CountOfTransf++;
            //}
            //else
            //{
            //    Group = "Программная инженерия";
            //    Study.Asm_economics.Text = "Архитектура вычислительных систем";
            //    Exams.Asm_economics.Text = "Архитектура вычислительных систем";
            //    Study.BtnASM_ECO.Text = "Писать ассемблерные вставки";
            //    BI = false;
            //    CountOfTransf++;
            //}
            //Studies.Asm_eco = 0;
            //Studies.Refresh();
            //RefreshCourse();
        }
    }
}
