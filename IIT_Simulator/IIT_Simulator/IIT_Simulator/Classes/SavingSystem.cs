using IIT_Simulator.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IIT_Simulator
{
    public static class SavingSystem
    {
        public static void ReadFile()
        {
            string fileName = GetPathToFile();

            if (!File.Exists(fileName))
            {
                States.InitializeStates();
                DaysControl.InitializeDays();
                Simulator.Cash.InitializeCash();
                Studies.InitializeSubjects();
                ExamsControl.InitializeExams();
                Simulator.Course.InitializeCourse();
                WriteAllData(fileName);
            }
            else
                ParseFile(fileName);
        }

        public static void WriteAllData(string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, true))
            {
                streamWriter.Write($"{DaysControl.DaysCounter};{DaysControl.Countdown};{DaysControl.DaysToGrant};{DaysControl.Session};" +
                                   $"{States.Satiety};{States.Sleep};{States.Happiness};{States.Studying};" +
                                   $"{Simulator.Cash.Money};{Simulator.Cash.Grant};" +
                                   $"{Studies.Programming};{Studies.Linal};{Studies.Math};{Studies.Asm_eco};" +
                                   $"{ExamsControl.ExamsCounter};" +
                                   $"{Simulator.Course.Group};{Simulator.Course.CourseNumber };{Simulator.Course.Semestr};{Simulator.Course.GotHelp}");
            }
        }

        private static void ParseFile(string fileName)
        {
            using (var streamReader = new StreamReader(fileName))
            {
                var array = streamReader.ReadToEnd().Trim().Split(';');

                if (array.Length == 19)
                {
                    DaysControl.DaysCounter = int.Parse(array[0]);
                    DaysControl.Countdown = int.Parse(array[1]);
                    DaysControl.DaysToGrant = int.Parse(array[2]);
                    DaysControl.Session = bool.Parse(array[3]);

                    States.Satiety = int.Parse(array[4]);
                    States.Sleep = int.Parse(array[5]);
                    States.Happiness = int.Parse(array[6]);
                    States.Studying = int.Parse(array[7]);

                    Simulator.Cash.Money = int.Parse(array[8]);
                    Simulator.Cash.Grant = int.Parse(array[9]);

                    Studies.Programming = int.Parse(array[10]);
                    Studies.Linal = int.Parse(array[11]);
                    Studies.Math = int.Parse(array[12]);
                    Studies.Asm_eco = int.Parse(array[13]);

                    ExamsControl.ExamsCounter = int.Parse(array[14]);

                    Simulator.Course.Group = array[15];
                    Simulator.Course.CourseNumber = int.Parse(array[16]);
                    Simulator.Course.Semestr = int.Parse(array[17]);
                    Simulator.Course.GotHelp = bool.Parse(array[18]);
                }
            }
        }

        public static string GetPathToFile() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),"data.txt");
    }
}
