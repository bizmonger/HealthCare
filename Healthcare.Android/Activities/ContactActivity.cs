using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = nameof(ContactActivity), Icon = "@drawable/icon")]
    class ContactActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Contact);
        }
    }
}