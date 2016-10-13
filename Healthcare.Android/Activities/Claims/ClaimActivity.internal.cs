using Android.Widget;
using ManageClaims;
using static Claims;

namespace Healthcare.Android
{
    partial class ClaimDetailActivity
    {
        void CreateViewModel()
        {
            var factory = new DependencyFactory(Global.IsIntegrated);
            var repository = factory.CreateClaimsRepository();

            var claimId = !string.IsNullOrEmpty(Intent.GetStringExtra("ClaimIdKey"))
                          ? Intent.GetStringExtra("ClaimIdKey")
                          : "no_claim_found";

            _viewModel = new ClaimsDetailViewModel(ClaimId.NewClaimId(claimId), _dispatcher, repository);
        }

        void Load()
        {
            _viewModel.Load();

            var serviceLabel = FindViewById<TextView>(Resource.Id.ServiceValue);
            serviceLabel.Text = _viewModel.Claim.IsSome()
                            ? _viewModel.Claim.Value.Service.Name.Item
                            : "";

            var providerLabel = FindViewById<TextView>(Resource.Id.ProviderValue);
            var provider = _viewModel.Claim.Value.Provider;
            providerLabel.Text = _viewModel.Claim.IsSome()
                            ? $"{provider.Name.First} {provider.Name.Last}"
                            : "";

            var officeLabel = FindViewById<TextView>(Resource.Id.OfficeValue);
            officeLabel.Text = _viewModel.Claim.IsSome()
                            ? _viewModel.Claim.Value.Office.Item
                            : "";

            var networkLabel = FindViewById<TextView>(Resource.Id.NetworkValue);
            networkLabel.Text = _viewModel.Claim.IsSome()
                            ? "need value"
                            : "";

            var providerChargedLabel = FindViewById<TextView>(Resource.Id.ProviderChargedValue);
            providerChargedLabel.Text = _viewModel.Claim.IsSome()
                            ? "need value"
                            : "";

            var networkDiscountLabel = FindViewById<TextView>(Resource.Id.NetworkDiscountValue);
            networkDiscountLabel.Text = _viewModel.Claim.IsSome()
                            ? "need value"
                            : "";

            var insurancePaidLabel = FindViewById<TextView>(Resource.Id.InsurancePaidLabel);
            insurancePaidLabel.Text = _viewModel.Claim.IsSome()
                            ? "need value"
                            : "";

            var yourPayLabel = FindViewById<TextView>(Resource.Id.YourPayValue);
            yourPayLabel.Text = _viewModel.Claim.IsSome()
                            ? "need value"
                            : "";
        }

        void MapCommands()
        {
            var paymentDetails = FindViewById<Button>(Resource.Id.PaymentDetails);
            paymentDetails.Click += (s, e) => _viewModel.ViewPaymentDetails.Execute(null);

            var serviceDetails = FindViewById<Button>(Resource.Id.ServiceDetails);
            serviceDetails.Click += (s, e) => _viewModel.ViewServiceDetails.Execute(null);
        }

        void MapNavigations()
        {
            _dispatcher.ServiceDetailsRequested += OnServiceDetailsRequested;
            _dispatcher.PaymentDetailsRequested += OnPaymentDetailsRequested;
        }

        void UnMapNavigations()
        {
            _dispatcher.ServiceDetailsRequested -= OnServiceDetailsRequested;
            _dispatcher.PaymentDetailsRequested -= OnPaymentDetailsRequested;
        }

        void OnServiceDetailsRequested(object sender, object e) =>
            StartActivity(typeof(ServiceDetailsActivity));

        void OnPaymentDetailsRequested(object sender, object e) =>
            StartActivity(typeof(PaymentDetailsActivity));
    }
}