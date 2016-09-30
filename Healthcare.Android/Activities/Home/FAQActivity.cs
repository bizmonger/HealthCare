
using Android.App;
using Android.OS;
using Android.Widget;

namespace Healthcare.Android
{
    [Activity(Label = "FAQ", Icon = "@drawable/icon")]
    class FAQActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FAQ);

            var tips = FindViewById<TextView>(Resource.Id.FAQValue);
            tips.Text = Utility.LoremIpsum(5, 20, 2, 4, 3);
        }
    }
}