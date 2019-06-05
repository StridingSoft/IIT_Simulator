using IIT_Simulator.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Achievements : ContentPage
	{
        Label childTtl, childTxt,
            luckyTtl, luckyTxt1, luckyTxt2,
            incorruptibleTtl, incorruptibleTxt, incorruptibleRwd,
            lifeHostTtl, lifeHostTxt, lifeHostRwd,
            unnoticedTtl, unnoticedTxt,
            unstableTtl, unstableTxt,
            ulearnGodTtl, ulearnGodTxt, ulearnGodRwd,
            onEdgeTtl, onEdgeTxt, onEdgeRwd,
            godLikeTtl, godLikeTxt, godLikeRwd,
            loserTtl, loserTxt, loserRwd,
            suicideTtl, suicideTxt;

        public Achievements ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            childTtl = Content.FindByName<Label>("childTitle");
            childTxt = Content.FindByName<Label>("childText");
            luckyTtl = Content.FindByName<Label>("luckyTitle");
            luckyTxt1 = Content.FindByName<Label>("luckyText1");
            luckyTxt2 = Content.FindByName<Label>("luckyText2");
            incorruptibleTtl = Content.FindByName<Label>("incorruptibleTitle");
            incorruptibleTxt = Content.FindByName<Label>("incorruptibleText");
            incorruptibleRwd = Content.FindByName<Label>("incorruptibleReward");
            lifeHostTtl = Content.FindByName<Label>("lifeHostTitle");
            lifeHostTxt = Content.FindByName<Label>("lifeHostText");
            lifeHostRwd = Content.FindByName<Label>("lifeHostReward");
            unnoticedTtl = Content.FindByName<Label>("unnoticedTitle");
            unnoticedTxt = Content.FindByName<Label>("unnoticedText");
            unstableTtl = Content.FindByName<Label>("unstableTitle");
            unstableTxt = Content.FindByName<Label>("unstableText");
            ulearnGodTtl = Content.FindByName<Label>("ulearnGodTitle");
            ulearnGodTxt = Content.FindByName<Label>("ulearnGodText");
            ulearnGodRwd = Content.FindByName<Label>("ulearnGodReward");
            onEdgeTtl = Content.FindByName<Label>("onEdgeTitle");
            onEdgeTxt = Content.FindByName<Label>("onEdgeText");
            onEdgeRwd = Content.FindByName<Label>("onEdgeReward");
            godLikeTtl = Content.FindByName<Label>("godLikeTitle");
            godLikeTxt = Content.FindByName<Label>("godLikeText");
            godLikeRwd = Content.FindByName<Label>("godLikeReward");
            loserTtl = Content.FindByName<Label>("loserTitle");
            loserTxt = Content.FindByName<Label>("loserText");
            loserRwd = Content.FindByName<Label>("loserReward");
            suicideTtl = Content.FindByName<Label>("suicideTitle");
            suicideTxt = Content.FindByName<Label>("suicideText");

            SavingSystem.ReadAchievementsFile();
            CheckAchievementsOnStart();
        }

        public void CheckTransfer()
        {
            if (Simulator.Achievements.TransferCounter == 3)
            {
                ActivateAchievement(unstableTtl, unstableTxt);
                GetAchievementAlert();
            }
        }

        public void CheckCorpus()
        {
            if (Simulator.Achievements.Corpus)
            {
                ActivateAchievement(luckyTxt1, luckyTxt2, luckyTtl);
                GetAchievementAlert();
            }
        }

        public void CheckClicks()
        {
            if (Simulator.Achievements.ClicksCounter == 666)
            {
                ActivateAchievement(childTxt, childTtl);
                GetAchievementAlert();
            }
        }

        public async void GetOffset()
        {
            if (Simulator.Achievements.ProgExCounter >= 3)
            {
                Simulator.Study.Programming = 100;
                await DisplayAlert("Автомат по программированию", "За отличную успеваемость по программированию, вы получаете автомат", "Ура!");
            }
        }

        public void CheckProgramming()
        {
            if (Simulator.Achievements.ProgExCounter >= 3)
                ActivateAchievement(ulearnGodTtl, ulearnGodTxt, ulearnGodRwd);
            if (Simulator.Achievements.ProgExCounter == 3)
                GetAchievementAlert();
        }

        public void CheckStates()
        {
            if (Simulator.States.Satiety == 1 || Simulator.States.Sleep == 1 || Simulator.States.Happiness == 1)
            {
                ActivateAchievement(onEdgeTtl, onEdgeTxt, onEdgeRwd);
                GetAchievementAlert();
                Simulator.Cash.Money += 1000;
                Simulator.Achievements.OnEdge = true;
            }
        }

        public void CheckWins()
        {
            if (Simulator.Statistics.GameWins == 3)
            {
                ActivateAchievement(godLikeTtl,godLikeTxt,godLikeRwd);
                GetAchievementAlert();
            }
        }

        public void CheckLoses()
        {
            if (Simulator.Statistics.GameLoses == 10)
            {
                ActivateAchievement(loserTtl, loserTxt, loserRwd);
                GetAchievementAlert();
            }
        }

        public void CheckGrant()
        {
            if (Simulator.Achievements.Uncorrupt)
            {
                ActivateAchievement(incorruptibleRwd, incorruptibleTtl, incorruptibleTxt);
                Simulator.Cash.Money += 200;
                GetAchievementAlert();
            }
        }
        public void CheckSuicide()
        {
            if (Simulator.Achievements.Suicide)
            {
                ActivateAchievement(suicideTtl, suicideTxt);
                GetAchievementAlert();
            }
        }

        public void CheckUnluck()
        { 
            if (Simulator.Achievements.Unnoticed)
            {
                ActivateAchievement(unnoticedTtl, unnoticedTxt);
                GetAchievementAlert();
            }
        }

        private void ActivateAchievement(params Label[] labels)
        {
            foreach (var label in labels)
            {
                label.TextColor = Color.DeepSkyBlue;
                label.TextDecorations = TextDecorations.Strikethrough;
            }
        }

        public void CheckAchievementsOnStart()
        {
            if (Simulator.Achievements.TransferCounter >= 3)
                ActivateAchievement(unstableTtl, unstableTxt);
            if (Simulator.Achievements.Corpus)
                ActivateAchievement(luckyTxt1, luckyTxt2, luckyTtl);
            if (Simulator.Achievements.ClicksCounter >= 666)
                ActivateAchievement(childTxt, childTtl);
            if (Simulator.Statistics.GameWins >= 3)
                ActivateAchievement(godLikeTtl, godLikeTxt, godLikeRwd);
            if (Simulator.Statistics.GameLoses >= 10)
                ActivateAchievement(loserTtl, loserTxt, loserRwd);
            if (Simulator.Achievements.Suicide)
                ActivateAchievement(suicideTtl, suicideTxt);
            if (Simulator.Achievements.Unnoticed)
                ActivateAchievement(unnoticedTtl, unnoticedTxt);
            if (Simulator.Cash.Grant == 0)
                ActivateAchievement(incorruptibleTtl, incorruptibleTxt, incorruptibleRwd);
            if (Simulator.Achievements.OnEdge)
                ActivateAchievement(onEdgeTtl, onEdgeTxt, onEdgeRwd);
            if (Simulator.Achievements.ProgExCounter >= 3)
                ActivateAchievement(ulearnGodTtl, ulearnGodTxt, ulearnGodRwd);
        }

        private async void GetAchievementAlert() => await DisplayAlert("Получено достижение.","Вы получили достижение, поздравляем!", "Ура!");
    }
}