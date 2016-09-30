using Android.App;
using Android.OS;
using Android.Widget;

namespace Healthcare.Android
{
    [Activity(Label = "Tips")]
    public class TipsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Tips);

            var tips = FindViewById<TextView>(Resource.Id.TipsValue);
            tips.Text = Utility.LoremIpsum(5, 20, 2, 4, 3);
        }
    }
}