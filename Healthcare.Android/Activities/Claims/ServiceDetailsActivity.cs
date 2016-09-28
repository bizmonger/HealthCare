using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = "Service Details")]
    public class ServiceDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ServiceDetails);
        }
    }
}