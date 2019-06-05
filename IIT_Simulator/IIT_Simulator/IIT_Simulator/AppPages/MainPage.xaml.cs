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
        public Achievements AchievementsPage;
        bool congr;

        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            SavingSystem.ReadStatisticsFile();

            needsPage = new NeedsPage(this);
            studyPage = new StudyPage(this, needsPage);
            deaneryPage = new DeaneryPage(this, examsPage, studyPage);
            examsPage = new ExamsPage(this);
            AchievementsPage = new Achievements();

            Children.Add(needsPage);
            Children.Add(studyPage);
            Children.Add(deaneryPage);
            Children.Add(examsPage);
            Children.Add(AchievementsPage);

            deaneryPage.CheckGroupAndRefresh();
            deaneryPage.BtnCorp.IsEnabled = !Simulator.Course.Corpus;
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

                AchievementsPage.CheckGrant();
                Simulator.Session.ExamsCounter = 0;

                Simulator.Study.InitializeSubjects();
                studyPage.Refresh();

                examsPage.DeactivateButtons();

                Simulator.Course.ChangeCourse();
                deaneryPage.RefreshCourse();
            }

            else if (Simulator.Schedule.Countdown == 0 && !Simulator.Schedule.IsSession)
            {
                Simulator.Schedule.IsSession = !Simulator.Schedule.IsSession;
                Simulator.Schedule.Countdown = 30;
                examsPage.ActivateButtons();
            }

            if (Simulator.Schedule.DaysToGrant == 0)
            {
                Simulator.Cash.CalculatePremium();
                Simulator.Cash.Money += Simulator.Cash.Grant + Simulator.Cash.Premium;
                Simulator.Statistics.MoneyCount += Simulator.Cash.Grant + Simulator.Cash.Premium;
                Simulator.Schedule.DaysToGrant = 30;
                needsPage.RefreshStates();
                needsPage.RefreshCash();
            }
            needsPage.RefreshDays();
        }
        
        public void DecreaseDays()
        {
            GetHelp();
            Simulator.Schedule.DaysCounter++;
            Simulator.Schedule.Countdown--;
            Simulator.Schedule.DaysToGrant--;
            ChangePeriodIfNeeded();
        }

        protected override void OnDisappearing()
        {
            File.Delete(SavingSystem.GetPathToFile("data.txt"));
            if (!Simulator.States.GameOver() && !Simulator.Schedule.IsDeducted && !Simulator.Schedule.IsGraduated && !Simulator.Course.Expelled)
                SavingSystem.WriteAllData(SavingSystem.GetPathToFile("data.txt"));
            File.Delete(SavingSystem.GetPathToFile("statistics.txt"));
            SavingSystem.WriteAllStatistics(SavingSystem.GetPathToFile("statistics.txt"));
            File.Delete(SavingSystem.GetPathToFile("achievements.txt"));
            SavingSystem.WriteAchievements(SavingSystem.GetPathToFile("achievements.txt"));
        }

        internal void RefreshCash()
        {
            needsPage.RefreshCash();
        }

        private static string maxNeeds = "maxmotives";
        private static string maxPerformance = "maxstudy";
        private static string addMoney = "motherlode";
        private static string upToCourse = "tolastsemestr";
        private static string progr = "progup";
        private static string reduceDays = "reducedays";

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
            else if (deaneryPage.GetCheatCode() == progr)
                Simulator.Achievements.ProgExCounter = 2;
            else if (deaneryPage.GetCheatCode() == reduceDays)
                Simulator.Schedule.Countdown = 1;
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

        public void ForceGameOverAlert()
        {
            if (Simulator.States.GameOver())
            {
                Simulator.Statistics.GameLoses++;
                AchievementsPage.CheckLoses();
                DispAlertAndPushPage("Вы проиграли!", "Студент умер. Хотите увидеть статистику?");
            }
            else if (Simulator.Schedule.IsDeducted)
            {
                Simulator.Statistics.GameLoses++;
                AchievementsPage.CheckLoses();
                DispAlertAndPushPage("Неуспеваемость!", "Студент был отчислен. Хотите увидеть статистику?");
            }
            else if (Simulator.Schedule.IsGraduated)
            {
                Simulator.Statistics.GameWins++;
                AchievementsPage.CheckWins();
                congr = true;
                DispAlertAndPushPage("Выпускной!", "Ваш студент только что закончил университет! Хотите увидеть статистику?");
            }
        }

        public async void DispAlertAndPushPage(string title, string message)
        {
            File.Delete(SavingSystem.GetPathToFile("statistics.txt"));
            SavingSystem.WriteAllStatistics(SavingSystem.GetPathToFile("statistics.txt"));
            bool res = await DisplayAlert(title,message, "Да","Нет");
            if (res)
                await DisplayAlert("Статистика", 
                    $"Кол-во выигрышей: {Simulator.Statistics.GameWins}{Environment.NewLine}" +
                    $"Кол-во проигрышей: {Simulator.Statistics.GameLoses}{Environment.NewLine}" +
                    $"Кол-во достижений: {Simulator.Statistics.Achievements}{Environment.NewLine}" +
                    $"Прожито дней: {Simulator.Schedule.DaysCounter}{Environment.NewLine}" +
                    $"Получено денег за игру: {Simulator.Statistics.MoneyCount}", "ОК");
            if (congr)
                await Navigation.PushAsync(new Winner());
            else
            {
                Simulator.Achievements.OnEdge = false;
                Simulator.Achievements.ProgExCounter = 0;
                await Navigation.PopAsync();
            }
        }

        private async void GetHelp()
        {
            if (NeedHelp())
            {
                bool res = await DisplayAlert("Добро пожаловать!", "Приветствую тебя, игрок! Ты попал в ИИТ симулятор." + Environment.NewLine +"Что, ты не знаешь что такое ИИТ? Это факультет ВУЗа ЧелГУ!" 
                                                + Environment.NewLine +"Подробнее: iit.csu.ru" 
                                                + Environment.NewLine+ "Начнем обучение?", "Давай!", "Нет");
                if (res)
                {
                    await DisplayAlert("Обучение", "Итак! Первая вкладка - потребности. Вам нужно следить за своим студентом чтобы он не умер, поэтому вовремя кормите его, укладывайте спать и водите развлекаться. Каждое действие отнимает один день и приближает вас к сессии...", "Далее");
                    await DisplayAlert("Обучение", "Вторая вкладка - учеба. Здесь вы можете качать навыки своего программиста (или бизнес-аналитика), чтобы успешно сдать сессию. Для успешной сдачи вам нужно не менее 50% успеваемости по каждому предмету", "Далее");
                    await DisplayAlert("Обучение", "Третья вкладка - деканат. Здесь вы можете сменить группу, получить помощь (раз за игру), получить сведения о своем курсе, а также попытаться поступить в анти-школу 'Корпус' (ключевое слово 'попытаться').", "Далее");
                    await DisplayAlert("Обучение", "Четвертая вкладка - экзамены. Эта вкладка становится доступна только во время сессии (см. вкладку потребности). Сдача одного экзамена отнимает 1 день. Возможны непредвиденные события, которые затруднят вам сдачу, но шанс не велик. Чтобы успешно сдать сессию, нужно сдать все экзамены. К тому же, чтобы остаться со стипендией, нужно на конец сессии иметь успеваемость >= 60.", "Далее");
                    await DisplayAlert("Обучение", "И, наконец, последняя вкладка - достижения. Здесь можно получить какие-то плюшки за выполнение определенных условий." + Environment.NewLine + "А, да, еще странички можно свайпать влево и вправо(удобно)." + Environment.NewLine + "А моя работа на этом закончена.Удачи!", "Закончить обучение");
                }
            }
        }

        private bool NeedHelp() => Simulator.Statistics.GameLoses == 0 && Simulator.Statistics.GameWins == 0 && Simulator.Schedule.DaysCounter == 1;

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
