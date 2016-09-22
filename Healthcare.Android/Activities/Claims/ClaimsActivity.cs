using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = nameof(ClaimsActivity))]
    partial class ClaimsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Claims);
        }

        protected override void OnStop()
        {
            base.OnStop();
            UnMapNavigations();
        }

        protected override void OnStart()
        {
            base.OnStart();
            MapNavigations();
        }

        void MapNavigations()
        {
            _dispatcher.ServiceDetailsRequested += OnServiceDetailsRequested;
            _dispatcher.PaymentDetailsRequested += OnPaymentDetailsRequested;
        }


        void OnServiceDetailsRequested(object sender, object e) =>
            StartActivity(typeof(ServiceDetailsActivity));

        void OnPaymentDetailsRequested(object sender, object e) =>
            StartActivity(typeof(PaymentDetailsActivity));

        void UnMapNavigations()
        {
            _dispatcher.ServiceDetailsRequested -= OnServiceDetailsRequested;
            _dispatcher.PaymentDetailsRequested -= OnPaymentDetailsRequested;
        }
    }
}