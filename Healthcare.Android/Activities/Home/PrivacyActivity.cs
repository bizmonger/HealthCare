using Android.App;
using Android.OS;
using Android.Widget;

namespace Healthcare.Android
{
    [Activity(Label = "Privacy", Icon = "@drawable/icon")]
    class PrivacyActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Privacy);

            var tips = FindViewById<TextView>(Resource.Id.PrivacyValue);
            tips.Text = Utility.LoremIpsum(5, 20, 2, 4, 3);
        }
    }
}