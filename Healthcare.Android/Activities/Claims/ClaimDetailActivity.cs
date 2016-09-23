using Android.App;
using Android.OS;
using Android.Widget;
using ManageClaims;
using static MockClaim;

namespace Healthcare.Android
{
    [Activity(Label = nameof(ClaimDetailActivity))]
    partial class ClaimDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ClaimDetail);
            MapCommands();
        }

        void MapCommands()
        {
            _viewModel = new ClaimsDetailViewModel(SomeClaimId, _dispatcher, _repository);

            var paymentDetails = FindViewById<Button>(Resource.Id.ServiceDetails);
            paymentDetails.Click += (s, e) => _viewModel.ViewPaymentDetails.Execute(null);

            var serviceDetails = FindViewById<Button>(Resource.Id.ServiceDetails);
            serviceDetails.Click += (s, e) => _viewModel.ViewServiceDetails.Execute(null);
        }

        protected override void OnStart()
        {
            base.OnStart();
            MapNavigations();
        }

        protected override void OnStop()
        {
            base.OnStop();
            UnMapNavigations();
        }
    }
}