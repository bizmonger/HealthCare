using Android.Widget;
using System;

namespace Healthcare.Android
{
    partial class AccountActivity
    {
        void CreateViewModel()
        {
            var factory = new DependencyFactory(Global.IsIntegrated);
            var PatientId = factory.GetPatientId();

            _viewModel = new ManageAccount.AccountViewModel(PatientId, _dispatcher);
        }

        void MapNavigations()
        {
            _dispatcher.ProfileRequested += OnProfileRequested;
            _dispatcher.DependentProfilesRequested += OnDependentsProfileRequested;
            _dispatcher.LoginSettingsRequested += OnLoginSettingsRequested;
            _dispatcher.FilesRequested += OnFilesRequested;
        }

        void UnMapNavigations()
        {
            _dispatcher.ProfileRequested -= OnProfileRequested;
            _dispatcher.DependentProfilesRequested -= OnDependentsProfileRequested;
            _dispatcher.LoginSettingsRequested -= OnLoginSettingsRequested;
            _dispatcher.FilesRequested -= OnFilesRequested;
        }

        void OnProfileRequested(object sender, object e) => StartActivity(typeof(ProfileActivity));
        void OnDependentsProfileRequested(object sender, EventArgs e) => StartActivity(typeof(DependentProfilesActivity));
        void OnLoginSettingsRequested(object sender, EventArgs e) => StartActivity(typeof(LoginSettingsActivity));
        void OnFilesRequested(object sender, object e) => StartActivity(typeof(FilesActivity));
    }
}