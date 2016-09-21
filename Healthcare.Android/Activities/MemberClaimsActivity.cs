using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = nameof(MemberClaimsActivity))]
    public class MemberClaimsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MemberClaims);
        }
    }
}