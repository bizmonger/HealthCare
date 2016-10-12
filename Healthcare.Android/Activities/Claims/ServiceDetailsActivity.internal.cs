using Android.Widget;
using ManageClaims;
using static Claims;

namespace Healthcare.Android
{
    partial class ServiceDetailsActivity
    {
        void CreateViewModel()
        {
            var factory = new RepositoryFactory(Global.IsIntegrated);
            var repository = factory.CreateClaimsRepository();

            var claimId = !string.IsNullOrEmpty(Intent.GetStringExtra("ClaimIdKey"))
                          ? Intent.GetStringExtra("ClaimIdKey")
                          : "no_claim_found";

            _viewModel = new ServiceDetailsViewModel(ClaimId.NewClaimId(claimId), repository);
        }

        void Load()
        {
            CreateViewModel();
            _viewModel.Load();

            var detailsLabel = FindViewById<TextView>(Resource.Id.DetailsValue);
            detailsLabel.Text = _viewModel.ServiceDetails.IsSome()
                                ? _viewModel.ServiceDetails.Value.Description.Item
                                : "no details provided";
        }
    }
}