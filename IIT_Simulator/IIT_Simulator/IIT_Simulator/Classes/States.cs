using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace IIT_Simulator
{
    public static class States
    {
        public static int Satiety { get; set; }
        public static int Sleep { get; set; }
        public static int Happiness { get; set; }
        public static int Studying { get; set; }

        public static void InitializeStates()
        {
            Satiety = 50;
            Sleep = 50;
            Happiness = 50;
            Studying = 0;
        }

        public static void RefreshLabels()
        {
            Satiety = RemoveOverflowing(Satiety);
            Sleep = RemoveOverflowing(Sleep);
            Happiness = RemoveOverflowing(Happiness);
            Studying = RemoveOverflowing(Studying);

            NeedsPage.EatPoints.Text = Satiety + "/100";
            NeedsPage.SleepPoints.Text = Sleep + "/100";
            NeedsPage.HappyPoints.Text = Happiness + "/100";
            NeedsPage.StudyPoints.Text = Studying + "/100";
        }

        public static void RefreshProgressBars()
        {
            NeedsPage.PbFood.Progress = Satiety * 0.01;
            NeedsPage.PbSleep.Progress = Sleep * 0.01;
            NeedsPage.PbHappiness.Progress = Happiness * 0.01;
            NeedsPage.PbStudying.Progress = Studying * 0.01;

            ChangeProgressBarColor(Satiety, NeedsPage.PbFood);
            ChangeProgressBarColor(Sleep, NeedsPage.PbSleep);
            ChangeProgressBarColor(Happiness, NeedsPage.PbHappiness);
            ChangeProgressBarColor(Studying, NeedsPage.PbStudying);
        }

        private static void ChangeProgressBarColor(int state, Xamarin.Forms.ProgressBar progressBar)
        {
            if (state < 40)
                progressBar.ProgressColor = Color.Red;
            else if (state < 70)
                progressBar.ProgressColor = Color.Yellow;
            else
                progressBar.ProgressColor = Color.Green;

        }

        private static int RemoveOverflowing(int state)
        {
            if (state >= 100)
                state = 100;
            return state;
        }

        public static bool GameOver() => Satiety <= 0 || Sleep <= 0 || Happiness <= 0;
    }
}
