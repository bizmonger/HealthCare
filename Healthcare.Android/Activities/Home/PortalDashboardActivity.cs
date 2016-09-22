using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = nameof(PortalDashboardActivity))]
    partial class PortalDashboardActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PortalDashboard);
            MapCommands();
        }

        protected override void OnStop()
        {
            base.OnStop();
            UnMapNavigations();
        }

        protected override void OnStart()
        {
            base.OnStart();
            MapNavigations();
        }
    }
}