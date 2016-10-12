using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = "Dependents")]
    partial class DependentProfilesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DependentProfiles);
            CreateViewModel();
            LoadListView();
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