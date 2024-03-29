using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = "Payment Details")]
    partial class PaymentDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PaymentDetails);
            CreateViewModel();
            Load();
        }
    }
}