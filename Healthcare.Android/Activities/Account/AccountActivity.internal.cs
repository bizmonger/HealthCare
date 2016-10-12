using Android.Widget;
using System;

namespace Healthcare.Android
{
    partial class AccountActivity
    {
        void MapCommands()
        {
            var myProfile = FindViewById<Button>(Resource.Id.MyProfile);
            myProfile.Click += (s, e) => _viewModel.ViewProfile.Execute(null);

            var deppendentsProfile = FindViewById<Button>(Resource.Id.DependentsProfile);
            deppendentsProfile.Click += (s, e) => _viewModel.ViewDependentProfiles.Execute(null);

            var loginSettings = FindViewById<Button>(Resource.Id.LoginSettings);
            loginSettings.Click += (s, e) => _viewModel.ViewLoginSettings.Execute(null);
        }

        void CreateViewModel()
        {
            var factory = new RepositoryFactory(Global.IsIntegrated);
            var memberId = factory.GetMemberId();

            _viewModel = new ManageAccount.AccountViewModel(memberId, _dispatcher);
        }

        void MapNavigations()
        {
            _dispatcher.ProfileRequested += OnProfileRequested;
            _dispatcher.DependentProfilesRequested += OnDependentsProfileRequested;
            _dispatcher.LoginSettingsRequested += OnLoginSettingsRequested;
        }

        void UnMapNavigations()
        {
            _dispatcher.ProfileRequested -= OnProfileRequested;
            _dispatcher.DependentProfilesRequested -= OnDependentsProfileRequested;
            _dispatcher.LoginSettingsRequested -= OnLoginSettingsRequested;
        }

        void OnProfileRequested(object sender, object e) => StartActivity(typeof(ProfileActivity));
        void OnDependentsProfileRequested(object sender, EventArgs e) => StartActivity(typeof(DependentProfilesActivity));
        void OnLoginSettingsRequested(object sender, EventArgs e) => StartActivity(typeof(LoginSettingsActivity));
    }
}