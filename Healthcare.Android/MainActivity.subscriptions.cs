using System;
using Android.Widget;

namespace Healthcare.Android
{
    public partial class MainActivity
    {
        void MapNavigations()
        {
            _dispatcher.SignInRequested += OnSignInRequested;
            _dispatcher.SignInSuccessful += OnSignInSuccessful;

            _dispatcher.RegistrationRequested += OnRegistrationRequested;
            _dispatcher.RegistrationSuccessful += OnRegistrationSuccessful;

            _dispatcher.IdRequested += OnIdRequested;
            _dispatcher.ProvidersRequested += OnProvidersRequested;
            _dispatcher.ContactRequested += OnContactRequested;
            _dispatcher.PrivacyRequested += OnPrivacyRequested;
            _dispatcher.FAQRequested += OnFAQRequested;
            _dispatcher.TipsRequested += OnTipsRequested;
        }

        void UnMapNavigations()
        {
            _dispatcher.SignInRequested -= OnSignInRequested;
            _dispatcher.SignInSuccessful -= OnSignInSuccessful;

            _dispatcher.RegistrationRequested -= OnRegistrationRequested;
            _dispatcher.RegistrationSuccessful -= OnRegistrationSuccessful;

            _dispatcher.IdRequested -= OnIdRequested;
            _dispatcher.ProvidersRequested -= OnProvidersRequested;
            _dispatcher.ContactRequested -= OnContactRequested;
            _dispatcher.PrivacyRequested -= OnPrivacyRequested;
            _dispatcher.FAQRequested -= OnFAQRequested;
            _dispatcher.TipsRequested -= OnTipsRequested;
        }

        void OnSignInSuccessful(object sender, EventArgs e) => StartActivity(typeof(SignInActivity));
        void OnSignInRequested(object sender, EventArgs e) => StartActivity(typeof(SignInActivity));
        void OnRegistrationRequested(object sender, EventArgs e) => StartActivity(typeof(RegisterActivity));
        void OnRegistrationSuccessful(object sender, object e) => StartActivity(typeof(PortalDashboardActivity));
        void OnIdRequested(object sender, EventArgs e) => StartActivity(typeof(IdCardActivity));
        void OnProvidersRequested(object sender, EventArgs e) => StartActivity(typeof(FindProvidersActivity));
        void OnContactRequested(object sender, EventArgs e) => StartActivity(typeof(ContactActivity));
        void OnPrivacyRequested(object sender, EventArgs e) => StartActivity(typeof(PrivacyActivity));
        void OnFAQRequested(object sender, EventArgs e) => StartActivity(typeof(FAQActivity));
        void OnTipsRequested(object sender, EventArgs e) => StartActivity(typeof(TipsActivity));

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