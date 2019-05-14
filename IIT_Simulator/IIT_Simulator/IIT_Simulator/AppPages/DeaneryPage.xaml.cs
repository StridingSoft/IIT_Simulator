using IIT_Simulator.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IIT_Simulator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeaneryPage : ContentPage
	{
        Label lblGroup, lblCourse, lblSemester;
        Entry tbCheatCode;
        Button btnGetHelp;

        MainPage mainPage;

		public DeaneryPage(MainPage mainPage, ExamsPage examsPage, StudyPage studyPage)
		{
			InitializeComponent ();

            this.mainPage = mainPage;

            lblGroup = Content.FindByName<Label>("Group");
            lblCourse = Content.FindByName<Label>("Course");
            lblSemester = Content.FindByName<Label>("Semestr");
            tbCheatCode = Content.FindByName<Entry>("CheatCode");
            btnGetHelp = Content.FindByName<Button>("BtnGetHelp");

            RefreshCourse();
		}
        
        private void BtnAcceptCode_Clicked(object sender, System.EventArgs e) => mainPage.Cheat();

        private async void BtnLeave_Clicked(object sender, System.EventArgs e)
        {
            bool res = await DisplayAlert("Процесс отчисления", "Вы уверены, что не хотите учиться?", "Да", "Нет");
            if (res)
            {
                Simulator.Course.Expelled = true;
                await DisplayAlert("Отчислен!", "Студент забрал документы из вуза", "ОК");
                await Navigation.PushAsync(new Menu());
            }
        }

        private void BtnCorpus_Clicked(object sender, System.EventArgs e)
        {
            //TODO
        }

        private async void BtnGetHelp_Clicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Прибавка!","Вам начислено 10 000(руб.)","Ура!");
            Simulator.Cash.Money += 10000;
            mainPage.RefreshCash();
            Simulator.Course.GotHelp = true;
            BtnGetHelp.IsEnabled = false;
        }

        //TODO
        private void BtnTransfer_Clicked(object sender, System.EventArgs e)
        {
            Simulator.Course.ChangeSpeciality();
            CheckGroupAndRefresh();
        }

        public void CheckGroupAndRefresh()
        {
            if (Simulator.Course.GroupChanged)
                Simulator.Course.Group = "Бизнес информатика";
            else
                Simulator.Course.Group = "Программная инженерия";
            mainPage.RefreshTransfBtnsAndLbls();
            //countoftrans++
            mainPage.RefreshLabels();
            RefreshCourse();
        }

        public void RefreshCourse()
        {
            lblGroup.Text = " Группа: " + Simulator.Course.Group;
            lblCourse.Text = " Курс: " + Simulator.Course.CourseNumber;
            lblSemester.Text = " Семестр: " + Simulator.Course.Semestr;
            if (Simulator.Course.GotHelp)
                btnGetHelp.IsEnabled = false;
        }

        public string GetCheatCode() => tbCheatCode.Text;

        public void SetCheatCode(string cheat) => tbCheatCode.Text = cheat;
    }
}