
using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = nameof(ClaimsActivity))]
    public class ClaimsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Claims);
        }
    }
}