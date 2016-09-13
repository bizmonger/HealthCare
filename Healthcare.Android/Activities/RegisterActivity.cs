using Android.App;
using Android.OS;
using Android.Widget;

namespace Healthcare.Android
{
    [Activity(Label = nameof(RegisterActivity))]
    partial class RegisterActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Register);

            var next = FindViewById<Button>(Resource.Id.next);
            next.Click += OnNext;
        }
    }
}