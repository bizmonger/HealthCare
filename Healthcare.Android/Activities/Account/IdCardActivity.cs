using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = nameof(IdCardActivity), Icon = "@drawable/icon")]
    partial class IdCardActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.IdCard);
            MapCommands();
        }
    }
}