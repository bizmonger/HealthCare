namespace Healthcare.Android
{
    partial class BenefitsActivity
    {
        void OnCoverageRequested(object sender, object e) => StartActivity(typeof(CoverageActivity));
        void OnPlanRequested(object sender, object e) => StartActivity(typeof(PlanActivity));
        void OnUsageRequested(object sender, object e) => StartActivity(typeof(UsageActivity));
    }
}