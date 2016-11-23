using Android.App;
using Android.OS;

namespace Healthcare.Android.Activities.Account
{
    [Activity(Label = "ReferralsActivity")]
    public class ReferralsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Referrals);
        }
    }
}