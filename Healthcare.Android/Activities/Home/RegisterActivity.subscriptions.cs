using Android.Widget;

namespace Healthcare.Android
{
    partial class RegisterActivity
    {
        void MapCommands()
        {
            var next = FindViewById<Button>(Resource.Id.next);
            next.Click += OnNext;
        }

        void MapNavigations() =>
            _dispatcher.RegistrationSuccessful += OnRegistrationSuccessful;

        void UnMapNavigations() =>
            _dispatcher.RegistrationSuccessful -= OnRegistrationSuccessful;

        void OnRegistrationSuccessful(object sender, object e) =>
            StartActivity(typeof(PortalDashboardActivity));
    }
}