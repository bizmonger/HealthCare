using Android.Widget;
using Healthcare.Android.Activities;
using ManageAccount;

namespace Healthcare.Android
{
    partial class LoginSettingsActivity
    {
        void MapCommands()
        {
            var changePassword = FindViewById<Button>(Resource.Id.ChangePassword);
            changePassword.Click += (s, e) => _viewModel.ChangePassword.Execute(null);
        }

        void CreateViewModel()
        {
            var factory = new DependencyFactory(Global.IsIntegrated);
            var PatientId = factory.GetPatientId();

            _viewModel = new LoginSettingsViewModel(PatientId, _dispatcher);
        }

        void MapNavigations() =>
            _dispatcher.ChangePasswordRequested += OnChangePassword;

        void UnMapNavigations() =>
            _dispatcher.ChangePasswordRequested -= OnChangePassword;

        void OnChangePassword(object sender, object e) => StartActivity(typeof(ChangePasswordActivity));
    }
}