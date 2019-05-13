using IIT_Simulator.Classes;
using System;
using System.IO;
using Xamarin.Forms;

namespace IIT_Simulator
{
    public partial class MainPage : TabbedPage
    {
        NeedsPage needsPage;
        StudyPage studyPage;
        DeaneryPage deaneryPage;
        ExamsPage examsPage;
        Achievements achievmentsPage;

        public MainPage()
        {
            InitializeComponent();

            needsPage = new NeedsPage(this);
            studyPage = new StudyPage(this, needsPage);
            deaneryPage = new DeaneryPage(this);
            examsPage = new ExamsPage(this);
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
            if (Simulator.Schedule.Countdown == 0 && Simulator.Schedule.IsSession)
            {
                if (Simulator.States.Studying < 50 || Simulator.Session.ExamsCounter < 4)
                    Simulator.Schedule.IsDeducted = true;

                Simulator.Schedule.IsSession = !Simulator.Schedule.IsSession;
                Simulator.Schedule.Countdown = 150;

                Simulator.Cash.CalculateGrant();
                Simulator.Cash.CheckPerformance();

                Simulator.Session.ExamsCounter = 0;

                Simulator.Study.InitializeSubjects();
                studyPage.Refresh();

                examsPage.DeactivateButtons();

                Simulator.Course.ChangeCourse();
            }
            else if (Simulator.Schedule.Countdown == 0 && !Simulator.Schedule.IsSession)
            {
                Simulator.Schedule.IsSession = !Simulator.Schedule.IsSession;
                Simulator.Schedule.Countdown = 30;
                examsPage.ActivateButtons();
            }

            if (Simulator.Schedule.DaysToGrant == 0)
            {
                Simulator.Cash.Money += Simulator.Cash.Grant;
                Simulator.Schedule.DaysToGrant = 30;
                needsPage.RefreshLabels();
                needsPage.RefreshCash();
            }
            needsPage.RefreshDays();
        }
        
        public void DecreaseDays()
        {
            Simulator.Schedule.DaysCounter++;
            Simulator.Schedule.Countdown--;
            Simulator.Schedule.DaysToGrant--;
            ChangePeriodIfNeeded();
        }

        protected override void OnDisappearing()
        {
            File.Delete(SavingSystem.GetPathToFile());
            if (!Simulator.States.GameOver() && !Simulator.Schedule.IsDeducted && !Simulator.Schedule.IsGraduated && !Simulator.Course.Expelled)
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
                Simulator.States.Satiety = 100;
                Simulator.States.Sleep = 100;
                Simulator.States.Happiness = 100;

            }
            else if (deaneryPage.GetCheatCode() == maxPerformance)
            {
                Simulator.Study.Programming = 100;
                Simulator.Study.Linal = 100;
                Simulator.Study.Asm_eco = 100;
                Simulator.Study.Math = 100;
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
