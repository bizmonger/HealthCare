using Android.Widget;

namespace Healthcare.Android
{
    partial class PortalDashboardActivity
    {
        void MapNavigations()
        {
            _dispatcher.IdRequested += (s, e) => StartActivity(typeof(IdCardActivity));
            _dispatcher.ClaimsRequested += (s, e) => StartActivity(typeof(ClaimsActivity));
            _dispatcher.UsageRequested += (s, e) => StartActivity(typeof(BenefitsActivity));
            _dispatcher.ContactRequested += (s, e) => StartActivity(typeof(ContactActivity));
            _dispatcher.ProvidersRequested += (s, e) => StartActivity(typeof(ProvidersActivity));
        }

        void MapCommands()
        {
            var idCard = FindViewById<Button>(Resource.Id.IdCard);
            idCard.Click += (s, e) => _viewModel.ViewIdCard.Execute(null);

            var claims = FindViewById<Button>(Resource.Id.Claims);
            claims.Click += (s, e) => _viewModel.ViewClaims.Execute(null);

            var benefits = FindViewById<Button>(Resource.Id.Benefits);
            benefits.Click += (s, e) => _viewModel.ViewBenefits.Execute(null);

            var providers = FindViewById<Button>(Resource.Id.Providers);
            providers.Click += (s, e) => _viewModel.ViewBenefits.Execute(null);
        }
    }
}