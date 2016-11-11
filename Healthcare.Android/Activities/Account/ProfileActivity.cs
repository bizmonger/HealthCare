using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = "Profile")]
    partial class ProfileActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Profile);
            CreateViewModel();
            MapCommands();
            UpdateUI();
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