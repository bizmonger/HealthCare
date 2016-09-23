namespace Healthcare.Android
{
    partial class ClaimDetailActivity
    {
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