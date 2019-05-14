using IIT_Simulator.AppPages;
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
            deaneryPage = new DeaneryPage(this, examsPage, studyPage);
            examsPage = new ExamsPage(this);
            achievmentsPage = new Achievements();

            Children.Add(needsPage);
            Children.Add(studyPage);
            Children.Add(deaneryPage);
            Children.Add(examsPage);
            Children.Add(achievmentsPage);

            NavigationPage.SetHasNavigationBar(this, false);
            deaneryPage.CheckGroupAndRefresh();
        }

        public void ChangePeriodIfNeeded() //не знаю как это исправить, все блять ломается нахуй
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
                needsPage.RefreshStates();
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
            needsPage.RefreshStates();
            needsPage.RefreshStatesPBars();
            studyPage.Refresh();
            needsPage.RefreshCash();
            deaneryPage.RefreshCourse();
            deaneryPage.SetCheatCode(string.Empty);
        }

        public void RefreshTransfBtnsAndLbls()
        {
            if (Simulator.Course.GroupChanged)
            {
                examsPage.lblAsm_eco.Text = "Экономическая теория и ее разделы";
                studyPage.lblAsm_eco.Text = "Экономическая теория и ее разделы";
                studyPage.btnAsm_eco.Text = "Рассчитать доход приложения";
            }
            else
            {
                examsPage.lblAsm_eco.Text = "Архитектура вычислительных систем";
                studyPage.lblAsm_eco.Text = "Архитектура вычислительных систем";
                studyPage.btnAsm_eco.Text = "Писать ассемблерные вставки";
            }
            studyPage.lblAsmEconomicsPoints.Text = $"{Simulator.Study.Asm_eco}/100";
            studyPage.pbAsmEconomicsPoints.Progress = Simulator.Study.Asm_eco * 0.01;
        }

        public async void ForceGameOverAlert()
        {
            if (Simulator.States.GameOver())
            {
                await DisplayAlert("Вы проиграли!", "Студент умер. Начните сначала", "ОК");
                await Navigation.PushAsync(new Menu());
            }
            else if (Simulator.Schedule.IsDeducted)
            {
                await DisplayAlert("Неуспеваемость!", "Студент был отчислен. Начните сначала", "ОК");
                await Navigation.PushAsync(new Menu());
            }
            else if (Simulator.Schedule.IsGraduated)
            {
                await DisplayAlert("Выпускной!", "Ваш студент только что закончил университет!", "Получить диплом");
                await Navigation.PushAsync(new Winner());
            }
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
            needsPage.RefreshStates();
        }

        internal void RefreshProgressBars()
        {
            needsPage.RefreshStatesPBars();
        }
    }
}
