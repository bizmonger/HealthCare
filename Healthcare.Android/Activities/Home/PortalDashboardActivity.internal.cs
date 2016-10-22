using Android.Widget;
using Home;

namespace Healthcare.Android
{
    partial class PortalDashboardActivity
    {
        void CreateViewModel()
        {
            var factory = new DependencyFactory(Global.IsIntegrated);
            var memberId = factory.GetMemberId();
            var repository = factory.CreateBenefitsRepository();
            _viewModel = new PortalViewModel(memberId, _dispatcher, repository);
        }

        void MapNavigations()
        {
            _dispatcher.IdRequested += OnIdRequested;
            _dispatcher.FamilyClaimsRequested += OnClaimsRequested;
            _dispatcher.CoverageRequested += OnCoverageRequested;
            _dispatcher.ContactRequested += OnContactRequested;
            _dispatcher.AccountRequested += OnAccountRequested;
        }

        void UnMapNavigations()
        {
            _dispatcher.IdRequested -= OnIdRequested;
            _dispatcher.FamilyClaimsRequested -= OnClaimsRequested;
            _dispatcher.CoverageRequested -= OnCoverageRequested;
            _dispatcher.ContactRequested -= OnContactRequested;
        }

        void MapCommands()
        {
            var idCard = FindViewById<Button>(Resource.Id.IdCard);
            idCard.Click += (s, e) => _viewModel.ViewIdCard.Execute(null);

            var claims = FindViewById<Button>(Resource.Id.Claims);
            claims.Click += (s, e) => _viewModel.ViewFamilyClaims.Execute(null);

            var benefits = FindViewById<Button>(Resource.Id.Benefits);
            benefits.Click += (s, e) => _viewModel.ViewBenefits.Execute(null);

            var contact = FindViewById<Button>(Resource.Id.Contact);
            contact.Click += (s, e) => _viewModel.ViewContactInfo.Execute(null);
        }
    }
}