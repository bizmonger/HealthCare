using System;
using Android.Widget;
using Home;

namespace Healthcare.Android
{
    partial class PortalDashboardActivity
    {
        void MapNavigations()
        {
            _dispatcher.IdRequested += OnIdRequested;
            _dispatcher.ClaimsRequested += OnClaimsRequested;
            _dispatcher.CoverageRequested += OnCoverageRequested;
            _dispatcher.ContactRequested += OnContactRequested;
            _dispatcher.FindProvidersRequested += OnFindProvidersRequested;
        }

        void UnMapNavigations()
        {
            _dispatcher.IdRequested += (s, e) => StartActivity(typeof(IdCardActivity));
            _dispatcher.ClaimsRequested += (s, e) => StartActivity(typeof(ClaimsActivity));
            _dispatcher.CoverageRequested += (s, e) => StartActivity(typeof(BenefitsActivity));
            _dispatcher.ContactRequested += (s, e) => StartActivity(typeof(ContactActivity));
            _dispatcher.FindProvidersRequested += (s, e) => StartActivity(typeof(FindProvidersActivity));
        }

        void MapCommands()
        {
            _viewModel = new PortalViewModel(_memberId, _dispatcher, _repository);

            var idCard = FindViewById<Button>(Resource.Id.IdCard);
            idCard.Click += (s, e) => _viewModel.ViewIdCard.Execute(null);

            var claims = FindViewById<Button>(Resource.Id.Claims);
            claims.Click += (s, e) => _viewModel.ViewClaims.Execute(null);

            var benefits = FindViewById<Button>(Resource.Id.Benefits);
            benefits.Click += (s, e) => _viewModel.ViewBenefits.Execute(null);

            var providers = FindViewById<Button>(Resource.Id.Providers);
            providers.Click += (s, e) => _viewModel.ViewProviders.Execute(null);
        }
    }
}