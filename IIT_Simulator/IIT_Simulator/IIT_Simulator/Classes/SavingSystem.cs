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
                Simulator.States.InitializeStates();
                Simulator.Schedule.InitializeDays();
                Simulator.Cash.InitializeCash();
                Simulator.Study.InitializeSubjects();
                Simulator.Session.InitializeExams();
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
                streamWriter.Write($"{Simulator.Schedule.DaysCounter};{Simulator.Schedule.Countdown};{Simulator.Schedule.DaysToGrant};{Simulator.Schedule.IsSession};" +
                                   $"{Simulator.States.Satiety};{Simulator.States.Sleep};{Simulator.States.Happiness};{Simulator.States.Studying};" +
                                   $"{Simulator.Cash.Money};{Simulator.Cash.Grant};" +
                                   $"{Simulator.Study.Programming};{Simulator.Study.Linal};{Simulator.Study.Math};{Simulator.Study.Asm_eco};" +
                                   $"{Simulator.Session.ExamsCounter};" +
                                   $"{Simulator.Course.Group};{Simulator.Course.CourseNumber };{Simulator.Course.Semestr};{Simulator.Course.GotHelp};{Simulator.Course.GroupChanged}");
            }
        }

        private static void ParseFile(string fileName)
        {
            using (var streamReader = new StreamReader(fileName))
            {
                var array = streamReader.ReadToEnd().Trim().Split(';');

                if (array.Length == 20)
                {
                    Simulator.Schedule.DaysCounter = int.Parse(array[0]);
                    Simulator.Schedule.Countdown = int.Parse(array[1]);
                    Simulator.Schedule.DaysToGrant = int.Parse(array[2]);
                    Simulator.Schedule.IsSession = bool.Parse(array[3]);

                    Simulator.States.Satiety = int.Parse(array[4]);
                    Simulator.States.Sleep = int.Parse(array[5]);
                    Simulator.States.Happiness = int.Parse(array[6]);
                    Simulator.States.Studying = int.Parse(array[7]);

                    Simulator.Cash.Money = int.Parse(array[8]);
                    Simulator.Cash.Grant = int.Parse(array[9]);

                    Simulator.Study.Programming = int.Parse(array[10]);
                    Simulator.Study.Linal = int.Parse(array[11]);
                    Simulator.Study.Math = int.Parse(array[12]);
                    Simulator.Study.Asm_eco = int.Parse(array[13]);

                    Simulator.Session.ExamsCounter = int.Parse(array[14]);

                    Simulator.Course.Group = array[15];
                    Simulator.Course.CourseNumber = int.Parse(array[16]);
                    Simulator.Course.Semestr = int.Parse(array[17]);
                    Simulator.Course.GotHelp = bool.Parse(array[18]);
                    Simulator.Course.GroupChanged = bool.Parse(array[19]);
                }
            }
        }

        public static string GetPathToFile() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),"data.txt");
    }
}
