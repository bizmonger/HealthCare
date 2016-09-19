using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = nameof(PlanActivity), Icon = "@drawable/icon")]
    class PlanActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Plan);
        }
    }
}