
using Android.App;
using Android.OS;

namespace Healthcare.Android.Activities
{
    [Activity(Label = "Change Password")]
    public class ChangePasswordActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ChangePassword);
        }
    }
}