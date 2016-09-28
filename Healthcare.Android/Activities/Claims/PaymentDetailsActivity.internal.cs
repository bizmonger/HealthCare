using Android.Widget;
using ManageClaims;
using TestAPI;
using static MockClaim;

namespace Healthcare.Android
{
    partial class PaymentDetailsActivity
    {
        void Load()
        {
            _viewModel = new PaymentDetailsViewModel(SomeClaimId, new MockClaimsRepository());
            _viewModel.Load();

            var detailsLabel = FindViewById<TextView>(Resource.Id.DetailsValue);
            detailsLabel.Text = _viewModel.PaymentDetails.IsSome()
                                ? _viewModel.PaymentDetails.Value.Paid.ToString("C2")
                                : "no details provided";
        }
    }
}