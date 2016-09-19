using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = nameof(CoverageActivity), Icon = "@drawable/icon")]
    class CoverageActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Coverage);
        }
    }
}