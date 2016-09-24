using Android.App;
using Android.OS;
using Home;
using InteractionLogic;
using ManageAccount;
using TestAPI;
using static MockMember;

namespace Healthcare.Android
{
    [Activity(Label = nameof(ProfileActivity))]
    public class ProfileActivity : Activity
    {
        ProfileViewModel _viewModel;
        readonly Dispatcher _diapatcher = Global.Dispatcher;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Profile);
            _viewModel = new ProfileViewModel(SomeMemberId, _diapatcher, new MockProfileRepository());
            _viewModel.Load();
        }
    }
}