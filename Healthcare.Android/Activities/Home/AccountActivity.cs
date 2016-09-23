using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = nameof(AccountActivity))]
    public class AccountActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Account);
        }
    }
}