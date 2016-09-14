using Android.App;
using Android.OS;
using Home;

namespace Healthcare.Android
{
    [Activity(Label = nameof(PortalDashboardActivity))]
    partial class PortalDashboardActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PortalDashboard);

            _viewModel = new PortalViewModel(_memberId, _dispatcher, _repository);
        }
    }
}