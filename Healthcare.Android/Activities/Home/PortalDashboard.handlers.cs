using System;

namespace Healthcare.Android
{
    partial class PortalDashboardActivity
    {
        void OnAccountRequested(object sender, EventArgs e) => StartActivity(typeof(AccountActivity));
        void OnContactRequested(object sender, EventArgs e) => StartActivity(typeof(ContactActivity));
        void OnCoverageRequested(object sender, object e) => StartActivity(typeof(BenefitsActivity));
        void OnClaimsRequested(object sender, object e) => StartActivity(typeof(ClaimsActivity));
        void OnIdRequested(object sender, EventArgs e) => StartActivity(typeof(IdCardActivity));
    }
}