using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Needs : ContentPage
    {
        int satiety = 50;
        int sleep = 50;
        int happiness = 50;

        public Needs()
        {
            InitializeComponent();
            eatPoints.Text = satiety + "/100";
            sleepPoints.Text = sleep + "/100";
            happyPoints.Text = happiness + "/100";
        }
        private void btnEat_Click(object sender, EventArgs e)
        {
            satiety = IncreaseParams(satiety, pbFood, eatPoints);
            sleep = DecreaseParams(sleep, pbSleep, sleepPoints);
            happiness = IncreaseParams(happiness, pbHappiness, happyPoints);
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            sleep = IncreaseParams(sleep, pbSleep, sleepPoints);
            satiety = DecreaseParams(satiety, pbFood, eatPoints);
            happiness = IncreaseParams(happiness, pbHappiness, happyPoints);
        }

        private int IncreaseParams(int state, ProgressBar pb, Label label)
        {
            state += 10;
            if (state > 100)
                state = 100;
            if (state < 40)
                pb.ProgressColor = Color.Red;
            else if (state < 75)
                pb.ProgressColor = Color.Yellow;
            else
                pb.ProgressColor = Color.Green;
            pb.Progress = state / 100.0;
            label.Text = state + "/100";
            return state;
        }

        private int DecreaseParams(int state, ProgressBar pb, Label label)
        {
            state -= 5;
            if (state < 0)
                state = 0;
            if (state < 40)
                pb.ProgressColor = Color.Red;
            else if (state < 75)
                pb.ProgressColor = Color.Yellow;
            else
                pb.ProgressColor = Color.Green;
            pb.Progress = state / 100.0;
            label.Text = state + "/100";
            return state;
        }
    }
}