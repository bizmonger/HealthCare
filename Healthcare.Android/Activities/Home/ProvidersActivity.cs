using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = "Providers")]
    public class ProvidersActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Providers);
        }
    }
}