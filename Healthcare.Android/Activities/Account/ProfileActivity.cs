using Android.App;
using Android.OS;
using ManageAccount;
using TestAPI;
using static MockMember;

namespace Healthcare.Android
{
    [Activity(Label = nameof(ProfileActivity))]
    partial class ProfileActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Profile);

            _viewModel = new ProfileViewModel(SomeMemberId, _diapatcher, new MockProfileRepository());
            _viewModel.Load();

            UpdateUI();
        }
    }
}