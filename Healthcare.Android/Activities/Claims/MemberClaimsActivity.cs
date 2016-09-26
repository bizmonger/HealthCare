using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = "Member Claims")]
    partial class MemberClaimsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MemberClaims);
            Load();
        }

        protected override void OnStart()
        {
            base.OnStart();
            MapNavigations();
        }

        protected override void OnStop()
        {
            base.OnStop();
            UnMapNavigations();
        }

        void MapNavigations() => _dispatcher.ClaimRequested += OnViewClaim;
        void UnMapNavigations() => _dispatcher.ClaimRequested += OnViewClaim;

        void OnViewClaim(object sender, object e) => StartActivity(typeof(ClaimDetailActivity));
    }
}