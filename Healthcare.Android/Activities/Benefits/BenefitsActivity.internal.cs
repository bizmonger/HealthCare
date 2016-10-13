using Android.Widget;
using ManageBenefits;

namespace Healthcare.Android
{
    partial class BenefitsActivity
    {
        void CreateViewModel()
        {
            var factory = new DependencyFactory(Global.IsIntegrated);
            var memberId = factory.GetMemberId();
            var repository = factory.CreateBenefitsRepository();

            _viewModel = new BenefitsOverviewViewModel(memberId, repository, _dispatcher);
        }

        void Load()
        {
            _viewModel.Load();

            var timeline = _viewModel.Overview.Value.Coverage.Summary.Effective;

            var effectiveFrom = FindViewById<TextView>(Resource.Id.EffectiveFromValue);
            effectiveFrom.Text = $"{timeline.ActiveFrom.Item}";

            var effectiveUntil = FindViewById<TextView>(Resource.Id.EffectiveUntilValue);
            effectiveUntil.Text = $"{timeline.ActiveUntil.Item}";

            var planCoverage = FindViewById<TextView>(Resource.Id.PlanCoverageValue);
            planCoverage.Text = _viewModel.Overview.IsSome()
                ? _viewModel.Overview.Value.Coverage.Summary.PlanType.Item
                : "No plan found";

            var network = FindViewById<TextView>(Resource.Id.NetworkValue);
            network.Text = _viewModel.Overview.IsSome()
                ? _viewModel.Overview.Value.Coverage.Summary.NetworkName.Item
                : "No network found";

            var groupNumber = FindViewById<TextView>(Resource.Id.GroupNumberValue);
            groupNumber.Text = _viewModel.Overview.IsSome()
                ? _viewModel.Overview.Value.Coverage.Summary.GroupNumber.Item
                : "No group found";
        }

        void MapCommands()
        {
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

        void UnMapNavigations()
        {
            _dispatcher.CoverageRequested -= OnCoverageRequested;
            _dispatcher.PlanRequested -= OnPlanRequested;
            _dispatcher.UsageRequested -= OnUsageRequested;
        }
    }
}