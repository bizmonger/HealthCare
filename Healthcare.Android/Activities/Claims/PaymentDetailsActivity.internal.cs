using Android.Widget;
using ManageClaims;
using static Claims;

namespace Healthcare.Android
{
    partial class PaymentDetailsActivity
    {
        void CreateViewModel()
        {
            var factory = new DependencyFactory(Global.IsIntegrated);
            var repository = factory.CreateClaimsRepository();

            var claimId = !string.IsNullOrEmpty(Intent.GetStringExtra("ClaimIdKey"))
                          ? Intent.GetStringExtra("ClaimIdKey")
                          : "no_claim_found";

            _viewModel = new PaymentDetailsViewModel(ClaimId.NewClaimId(claimId), repository);
        }

        void Load()
        {
            CreateViewModel();
            _viewModel.Load();

            var detailsLabel = FindViewById<TextView>(Resource.Id.DetailsValue);
            detailsLabel.Text = _viewModel.PaymentDetails.IsSome()
                                ? _viewModel.PaymentDetails.Value.Paid.ToString("C2")
                                : "no details provided";
        }
    }
}