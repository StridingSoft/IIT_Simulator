using IIT_Simulator.AppPages;
using IIT_Simulator.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IIT_Simulator
{
    public static class SavingSystem
    {
        static DifficultyPage difPage = new DifficultyPage();
        public static void ReadDataFile()
        {
            string fileName = GetPathToFile("data.txt");

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
                ParseDataFile(fileName);
        }

        public static void WriteAllData(string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, true))
            {
                streamWriter.Write($"{Simulator.Schedule.DaysCounter};{Simulator.Schedule.Countdown};{Simulator.Schedule.DaysToGrant};{Simulator.Schedule.IsSession};" +
                                   $"{Simulator.States.Satiety};{Simulator.States.Sleep};{Simulator.States.Happiness};{Simulator.States.Studying};" +
                                   $"{Simulator.Cash.Money};{Simulator.Cash.Grant};{Simulator.Cash.Premium};" +
                                   $"{Simulator.Study.Programming};{Simulator.Study.Linal};{Simulator.Study.Math};{Simulator.Study.Asm_eco};" +
                                   $"{Simulator.Session.ExamsCounter};" +
                                   $"{Simulator.Course.Group};{Simulator.Course.CourseNumber };{Simulator.Course.Semestr};{Simulator.Course.GotHelp};{Simulator.Course.GroupChanged};{Simulator.Course.Corpus};" +
                                   $"{Course.CoursesCount}");
            }
        }


        private static void ParseDataFile(string fileName)
        {
            using (var streamReader = new StreamReader(fileName))
            {
                var array = streamReader.ReadToEnd().Trim().Split(';');

                if (array.Length == 23)
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
                    Simulator.Cash.Premium = int.Parse(array[10]);

                    Simulator.Study.Programming = int.Parse(array[11]);
                    Simulator.Study.Linal = int.Parse(array[12]);
                    Simulator.Study.Math = int.Parse(array[13]);
                    Simulator.Study.Asm_eco = int.Parse(array[14]);

                    Simulator.Session.ExamsCounter = int.Parse(array[15]);

                    Simulator.Course.Group = array[16];
                    Simulator.Course.CourseNumber = int.Parse(array[17]);
                    Simulator.Course.Semestr = int.Parse(array[18]);
                    Simulator.Course.GotHelp = bool.Parse(array[19]);
                    Simulator.Course.GroupChanged = bool.Parse(array[20]);
                    Simulator.Course.Corpus = bool.Parse(array[21]);

                    Course.CoursesCount = int.Parse(array[22]);
                }
            }
        }

        public static void ReadStatisticsFile()
        {
            string fileName = GetPathToFile("statistics.txt");
            Simulator.Statistics.InitializeStatistics();

            if (!File.Exists(fileName))
                WriteAllStatistics(fileName);
            else
                ParseStatisticsFile(fileName);
        }

        public static void WriteAllStatistics(string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, true))
            {
                streamWriter.Write($"{Simulator.Statistics.GameWins};{Simulator.Statistics.GameLoses};{Simulator.Statistics.Achievements}");
            }
        }

        private static void ParseStatisticsFile(string fileName) //TODO: new page with statistics
        {
            using (var streamReader = new StreamReader(fileName))
            {
                var array = streamReader.ReadToEnd().Trim().Split(';');

                if (array.Length == 3)
                {
                    Simulator.Statistics.GameWins = int.Parse(array[0]);
                    Simulator.Statistics.GameLoses = int.Parse(array[1]);
                    Simulator.Statistics.Achievements = int.Parse(array[2]);
                }
            }
        }

        public static void ReadAchievementsFile()
        {
            string fileName = GetPathToFile("achievements.txt");

            if (!File.Exists(fileName))
            {
                Simulator.Achievements.InitializeAchievements();
                WriteAchievements(fileName);
            }
            else
                ParseAchievementFile(fileName);
        }

        private static void ParseAchievementFile(string fileName)
        {
            using (var streamReader = new StreamReader(fileName))
            {
                var array = streamReader.ReadToEnd().Trim().Split(';');

                if (array.Length == 7)
                {
                    Simulator.Achievements.Unnoticed = bool.Parse(array[0]);
                    Simulator.Achievements.TransferCounter = int.Parse(array[1]);
                    Simulator.Achievements.ClicksCounter = int.Parse(array[2]);
                    Simulator.Achievements.Corpus = bool.Parse(array[3]);
                    Simulator.Achievements.Suicide = bool.Parse(array[4]);
                    Simulator.Achievements.OnEdge = bool.Parse(array[5]);
                    Simulator.Achievements.ProgExCounter = int.Parse(array[6]);
                }
            }
        }

        public static void WriteAchievements(string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, true))
            {
                streamWriter.Write($"{Simulator.Achievements.Unnoticed};{Simulator.Achievements.TransferCounter};" +
                                   $"{Simulator.Achievements.ClicksCounter};{Simulator.Achievements.Corpus};" +
                                   $"{Simulator.Achievements.Suicide};{Simulator.Achievements.OnEdge};{Simulator.Achievements.ProgExCounter}");
            }
        }

        public static string GetPathToFile(string name) => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),name);
    }
}
