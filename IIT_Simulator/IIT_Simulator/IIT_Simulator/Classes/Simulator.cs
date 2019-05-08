using System;
using System.Collections.Generic;
using System.Text;

namespace IIT_Simulator.Classes
{
    public static class Simulator
    {
        public static Cash Cash = new Cash();
        public static Course Course = new Course();
    }

    public class Cash
    {
        public int Money;
        public int Grant;
        private int fixedGrant = 1800;

        public void InitializeCash()
        {
            Money = 1500;
            Grant = fixedGrant;
        }

        public  void CalculateGrant() => Grant = Convert.ToInt32(fixedGrant * (1 - (80 - States.Studying) * 0.01));

        public  void CheckPerformance()
        {
            if (States.Studying < 60)
                Grant = 0;
        }
    }


    public class Course
    {
        public  string Group;
        public  int CourseNumber;
        public  int Semestr;
        public  bool Expelled;
        public  bool GotHelp;

        public  void InitializeCourse()
        {
            Group = "Программная инженерия";
            CourseNumber = 1;
            Semestr = 1;
            GotHelp = false;
        }

        public  void RefreshCourse()
        {
            Deanery.Group.Text = " Группа: " + Group;
            Deanery.Course.Text = " Курс: " + CourseNumber;
            Deanery.Semestr.Text = " Семестр: " + Semestr;
            if (GotHelp)
                Deanery.BtnGetHelp.IsEnabled = false;
        }

        public  void ChangeCourse()
        {
            Semestr++;

            if (Semestr % 2 != 0)
            {
                CourseNumber++;
                Semestr = 1;
            }
            if (CourseNumber == 5)
                DaysControl.Congratulate = true;
        }

        public  void ChangeSpeciality()
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
