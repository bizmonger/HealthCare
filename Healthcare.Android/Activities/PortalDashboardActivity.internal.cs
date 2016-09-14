using Android.Widget;

namespace Healthcare.Android
{
    partial class PortalDashboardActivity
    {
        void MapNavigations()
        {
            _dispatcher.IdRequested += (s, e) => _viewModel.ViewIdCard.Execute(null);
            _dispatcher.ClaimsRequested += (s, e) => _viewModel.ViewClaims.Execute(null);
            _dispatcher.ProvidersRequested += (s, e) => _viewModel.ViewProviders.Execute(null);
            _dispatcher.ContactRequested += (s, e) => _viewModel.ViewBenefits.Execute(null);
            _dispatcher.ProvidersRequested += (s, e) => _viewModel.ViewProviders.Execute(null);
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