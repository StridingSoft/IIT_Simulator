using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Achievements : ContentPage
	{
        Label childTtl, childTxt,
            luckyTtl, luckyTxt,
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

            childTtl = Content.FindByName<Label>("childTitle");
            childTxt = Content.FindByName<Label>("childText");
            luckyTtl = Content.FindByName<Label>("luckyTitle");
            luckyTxt = Content.FindByName<Label>("luckyText");
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
            suicideTtl = Content.FindByName<Label>("suicudeTitle");
            suicideTxt = Content.FindByName<Label>("suicideText");
        }

        public void ActivateAchievement(Label label)
        {
            label.BackgroundColor = Color.DeepSkyBlue;
        }
	}
}