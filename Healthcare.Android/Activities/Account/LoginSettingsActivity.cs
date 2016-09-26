using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = "Login Settings")]
    public class LoginSettingsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LoginSettings);
        }
    }
}