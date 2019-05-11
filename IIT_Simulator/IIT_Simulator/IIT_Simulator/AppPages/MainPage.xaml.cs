using IIT_Simulator.Classes;
using System;
using System.IO;
using Xamarin.Forms;

namespace IIT_Simulator
{
    public partial class MainPage : TabbedPage
    {
        NeedsPage needsPage;
        Study studyPage;
        Deanery deaneryPage;
        Exams examsPage;
        Achievements achievmentsPage;

        public MainPage()
        {
            InitializeComponent();

            needsPage = new NeedsPage(this);
            studyPage = new Study(this, needsPage);
            deaneryPage = new Deanery(this);
            examsPage = new Exams(this);
            achievmentsPage = new Achievements();

            Children.Add(needsPage);
            Children.Add(studyPage);
            Children.Add(deaneryPage);
            Children.Add(examsPage);
            Children.Add(achievmentsPage);

            NavigationPage.SetHasNavigationBar(this, false);
        }

        public void ChangePeriodIfNeeded()
        {
            if (DaysControl.Countdown == 0 && DaysControl.Session)
            {
                if (States.Studying < 50 || ExamsControl.ExamsCounter < 4)
                    DaysControl.Deducted = true;

                DaysControl.Session = !DaysControl.Session;
                DaysControl.Countdown = 150;

                Simulator.Cash.CalculateGrant();
                Simulator.Cash.CheckPerformance();

                ExamsControl.ExamsCounter = 0;

                Studies.InitializeSubjects();
                studyPage.Refresh();

                examsPage.DeactivateButtons();

                Simulator.Course.ChangeCourse();
            }
            else if (DaysControl.Countdown == 0 && !DaysControl.Session)
            {
                DaysControl.Session = !DaysControl.Session;
                DaysControl.Countdown = 30;
                examsPage.ActivateButtons();
            }
            if (DaysControl.DaysToGrant == 0)
            {
                Simulator.Cash.Money += Simulator.Cash.Grant;
                DaysControl.DaysToGrant = 30;
                needsPage.RefreshLabels();
                needsPage.RefreshCash();
            }
            needsPage.RefreshDays();
        }
        
        public void DecreaseDays()
        {
            DaysControl.DaysCounter++;
            DaysControl.Countdown--;
            DaysControl.DaysToGrant--;
            ChangePeriodIfNeeded();
        }

        protected override void OnDisappearing()
        {
            File.Delete(SavingSystem.GetPathToFile());
            if (!States.GameOver() && !DaysControl.Deducted && !DaysControl.Congratulate && !Simulator.Course.Expelled)
                SavingSystem.WriteAllData(SavingSystem.GetPathToFile()); 
        }

        internal void RefreshCash()
        {
            needsPage.RefreshCash();
        }

        private static string maxNeeds = "maxmotives";
        private static string maxPerformance = "maxstudy";
        private static string addMoney = "motherlode";
        private static string upToCourse = "tolastsemestr";

        public void Cheat()
        {
            if (deaneryPage.GetCheatCode() == maxNeeds)
            {
                States.Satiety = 100;
                States.Sleep = 100;
                States.Happiness = 100;

            }
            else if (deaneryPage.GetCheatCode() == maxPerformance)
            {
                Studies.Programming = 100;
                Studies.Linal = 100;
                Studies.Asm_eco = 100;
                Studies.Math = 100;
            }
            else if (deaneryPage.GetCheatCode() == addMoney)
                Simulator.Cash.Money += 5000;
            else if (deaneryPage.GetCheatCode() == upToCourse)
            {
                Simulator.Course.CourseNumber = 4;
                Simulator.Course.Semestr = 2;
            }

            needsPage.RefreshLabels();
            needsPage.RefreshProgressBars();
            studyPage.Refresh();
            needsPage.RefreshCash();
            deaneryPage.RefreshCourse();
            deaneryPage.SetCheatCode(""); // TODO string.Empty
        }

        internal void RefreshStates()
        {
            studyPage.RefreshStates();
        }

        internal void RefreshDays()
        {
            needsPage.RefreshDays();
        }

        internal void RefreshLabels()
        {
            needsPage.RefreshLabels();
        }

        internal void RefreshProgressBars()
        {
            needsPage.RefreshProgressBars();
        }
    }
}
