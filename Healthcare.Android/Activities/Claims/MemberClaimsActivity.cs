using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = nameof(MemberClaimsActivity))]
    partial class MemberClaimsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MemberClaims);
            Load();
        }
    }
}