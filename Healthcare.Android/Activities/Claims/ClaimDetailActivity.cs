using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = "Claim")]
    partial class ClaimDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ClaimDetail);

            CreateViewModel();
            Load();
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