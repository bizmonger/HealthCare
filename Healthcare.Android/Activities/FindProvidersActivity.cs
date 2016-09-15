using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = nameof(FindProvidersActivity), Icon = "@drawable/icon")]
    partial class FindProvidersActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FindProviders);
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