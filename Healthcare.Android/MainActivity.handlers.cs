using System;

namespace Healthcare.Android
{
    partial class MainActivity
    {
        void OnSignInSuccessful(object sender, EventArgs e) => StartActivity(typeof(SignInActivity));
        void OnSignInRequested(object sender, EventArgs e) => StartActivity(typeof(SignInActivity));
        void OnRegistrationRequested(object sender, EventArgs e) => StartActivity(typeof(RegisterActivity));
        void OnIdRequested(object sender, EventArgs e) => StartActivity(typeof(IdCardActivity));
        void OnContactRequested(object sender, EventArgs e) => StartActivity(typeof(ContactActivity));
        void OnPrivacyRequested(object sender, EventArgs e) => StartActivity(typeof(PrivacyActivity));
        void OnFAQRequested(object sender, EventArgs e) => StartActivity(typeof(FAQActivity));
        void OnTipsRequested(object sender, EventArgs e) => StartActivity(typeof(TipsActivity));
    }
}