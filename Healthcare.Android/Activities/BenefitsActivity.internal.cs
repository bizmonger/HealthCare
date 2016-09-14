using Android.Widget;
using ManageBenefits;

namespace Healthcare.Android
{
    partial class BenefitsActivity
    {
        void MapCommands()
        {
            _viewModel = new BenefitsOverviewViewModel(_repository, _dispatcher, _account);
            var coverage = FindViewById<Button>(Resource.Id.Coverage);
            coverage.Click += (s, e) => _viewModel.ViewCoverage.Execute(null);

            var plan = FindViewById<Button>(Resource.Id.PlanBennefits);
            plan.Click += (s, e) => _viewModel.ViewPlan.Execute(null);

            var usage = FindViewById<Button>(Resource.Id.Usage);
            usage.Click += (s, e) => _viewModel.ViewUsage.Execute(null);
        }

        void MapNavigations()
        {
            _dispatcher.CoverageRequested += OnCoverageRequested;
            _dispatcher.PlanRequested += OnPlanRequested;
            _dispatcher.UsageRequested += OnUsageRequested;
        }
    }
}