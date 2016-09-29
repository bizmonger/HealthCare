using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = "Contact", Icon = "@drawable/icon")]
    partial class ContactActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Contact);
            Load();
        }
    }
}