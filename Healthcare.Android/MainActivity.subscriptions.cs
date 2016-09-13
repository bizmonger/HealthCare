using Android.Widget;

namespace Healthcare.Android
{
    public partial class MainActivity
    {
        void MapNavigations()
        {
            _dispatcher.SignInRequested += (s, e) => StartActivity(typeof(SignInActivity));
            _dispatcher.SignInSuccessful += (s, e) => StartActivity(typeof(SignInActivity));

            _dispatcher.RegistrationRequested += (s, e) => StartActivity(typeof(RegisterActivity));
            _dispatcher.RegistrationSuccessful += (s, e) => StartActivity(typeof(PortalDashboardActivity));

            _dispatcher.IdRequested += (s, e) => StartActivity(typeof(IdCardActivity));
            _dispatcher.ProvidersRequested += (s, e) => StartActivity(typeof(FindProvidersActivity));
            _dispatcher.ContactRequested += (s, e) => StartActivity(typeof(ContactActivity));
            _dispatcher.PrivacyRequested += (s, e) => StartActivity(typeof(PrivacyActivity));
            _dispatcher.FAQRequested += (s, e) => StartActivity(typeof(FAQActivity));
            _dispatcher.TipsRequested += (s, e) => StartActivity(typeof(TipsActivity));
        }

        void MapCommands()
        {
            var signIn = FindViewById<Button>(Resource.Id.SignIn);
            signIn.Click += (s, e) => _viewModel.SignIn.Execute(null);

            var register = FindViewById<TextView>(Resource.Id.Register);
            register.Click += (s, e) => _viewModel.Register.Execute(null);

            var tips = FindViewById<Button>(Resource.Id.Tips);
            tips.Click += (s, e) => _viewModel.ViewTips.Execute(null);

            var privacy = FindViewById<Button>(Resource.Id.Privacy);
            privacy.Click += (s, e) => _viewModel.ViewPrivacy.Execute(null);

            var faq = FindViewById<Button>(Resource.Id.FAQ);
            faq.Click += (s, e) => _viewModel.ViewFAQ.Execute(null);

            var idCard = FindViewById<Button>(Resource.Id.IdCard);
            idCard.Click += (s, e) => _viewModel.TryViewIdCard.Execute(null);

            var providers = FindViewById<Button>(Resource.Id.Providers);
            providers.Click += (s, e) => _viewModel.ViewProviders.Execute(null);

            var contact = FindViewById<Button>(Resource.Id.Contact);
            contact.Click += (s, e) => _viewModel.ViewContact.Execute(null);
        }
    }
}