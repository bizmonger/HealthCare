using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = nameof(UsageActivity), Icon = "@drawable/icon")]
    class UsageActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Usage);
        }
    }
}