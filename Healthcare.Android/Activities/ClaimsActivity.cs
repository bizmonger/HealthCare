using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = nameof(ClaimsActivity))]
    partial class ClaimsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Claims);
            Load();
        }

        protected override void OnStop()
        {
            base.OnStop();
            UnMapNavigations();
        }

        protected override void OnStart()
        {
            base.OnStart();
            MapNavigations();
        }

        void MapNavigations() =>
            _dispatcher.MemberClaimsRequested += OnMemberClaimsRequested;

        void OnMemberClaimsRequested(object sender, object e) =>
            StartActivity(typeof(MemberClaimsActivity));

        void UnMapNavigations() =>
            _dispatcher.MemberClaimsRequested -= OnMemberClaimsRequested;
    }
}