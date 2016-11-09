using Android.App;
using Android.OS;
using InteractionLogic;
using ManageAccount;

namespace Healthcare.Android
{
    [Activity(Label = "Login Settings")]
    partial class LoginSettingsActivity : Activity
    {


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LoginSettings);
            CreateViewModel();
            MapCommands();
        }

        protected override void OnStart()
        {
            base.OnStart();
            MapNavigations();
        }

        protected override void OnStop()
        {
            base.OnStop();
            UnMapNavigations();
        }
    }
}