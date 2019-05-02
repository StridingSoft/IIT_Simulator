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
                CashControl.InitializeCash();
                Studies.InitializeSubjects();
                ExamsControl.InitializeExams();
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
                                   $"{CashControl.Money};{CashControl.Grant};" +
                                   $"{Studies.Programming};{Studies.Linal};{Studies.Math};{Studies.Asm_eco};" +
                                   $"{ExamsControl.ExamsCounter}");
            }
        }

        private static void ParseFile(string fileName)
        {
            using (var streamReader = new StreamReader(fileName))
            {
                var array = streamReader.ReadToEnd().Trim().Split(';');
                if (array.Length == 15)
                {
                    DaysControl.DaysCounter = int.Parse(array[0]);
                    DaysControl.Countdown = int.Parse(array[1]);
                    DaysControl.DaysToGrant = int.Parse(array[2]);
                    DaysControl.Session = bool.Parse(array[3]);

                    States.Satiety = int.Parse(array[4]);
                    States.Sleep = int.Parse(array[5]);
                    States.Happiness = int.Parse(array[6]);
                    States.Studying = int.Parse(array[7]);

                    CashControl.Money = int.Parse(array[8]);
                    CashControl.Grant = int.Parse(array[9]);

                    Studies.Programming = int.Parse(array[10]);
                    Studies.Linal = int.Parse(array[11]);
                    Studies.Math = int.Parse(array[12]);
                    Studies.Asm_eco = int.Parse(array[13]);

                    ExamsControl.ExamsCounter = int.Parse(array[14]);
                }
            }
        }

        public static string GetPathToFile() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),"data.txt");
    }
}
