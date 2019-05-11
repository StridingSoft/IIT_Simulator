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

        public void InitializeCourse()
        {
            Group = "Программная инженерия";
            CourseNumber = 1;
            Semestr = 1;
            GotHelp = false;
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
