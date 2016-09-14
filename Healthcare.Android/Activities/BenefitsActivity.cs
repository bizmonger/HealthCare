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

            MapNavigations();
            MapCommands();
        }
    }
}