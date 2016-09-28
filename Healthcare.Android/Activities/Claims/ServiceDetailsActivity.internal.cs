using Android.Widget;
using ManageClaims;
using TestAPI;
using static MockClaim;

namespace Healthcare.Android
{
    partial class ServiceDetailsActivity
    {
        void Load()
        {
            _viewModel = new ServiceDetailsViewModel(SomeClaimId, new MockClaimsRepository());
            _viewModel.Load();

            var detailsLabel = FindViewById<TextView>(Resource.Id.DetailsValue);
            detailsLabel.Text = _viewModel.ServiceDetails.IsSome()
                                ? _viewModel.ServiceDetails.Value.Description.Item
                                : "no details provided";
        }
    }
}