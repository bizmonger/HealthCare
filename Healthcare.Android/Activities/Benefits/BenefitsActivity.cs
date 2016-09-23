using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = nameof(BenefitsActivity))]
    partial class BenefitsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Benefits);
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