namespace Healthcare.Android
{
    partial class BenefitsActivity
    {
        void OnCoverageRequested(object sender, object e) => StartActivity(typeof(CoverageActivity));
        void OnUsageRequested(object sender, object e) => StartActivity(typeof(UsageActivity));
    }
}