using Android.Widget;
using ManageBenefits;

namespace Healthcare.Android
{
    partial class BenefitsActivity
    {
        void CreateViewModel()
        {
            var factory = new DependencyFactory(Global.IsIntegrated);
            var PatientId = factory.GetPatientId();
            var repository = factory.CreateBenefitsRepository();

            _viewModel = new BenefitsOverviewViewModel(PatientId, repository, _dispatcher);
        }

        void Load()
        {
            _viewModel.Load();

            var summary = _viewModel.Summary.Value;

            var planName = FindViewById<TextView>(Resource.Id.PlanName);
            planName.Text = _viewModel.Summary.IsSome()
                           ? summary.PlanType.Item
                           : "no plan exists";

            var deductable = FindViewById<TextView>(Resource.Id.DeductableValue);
            deductable.Text = _viewModel.Summary.IsSome()
                           ? summary.Deductable.Total.ToString("C2")
                           : "no deductable exists";

            var outOfPocket = FindViewById<TextView>(Resource.Id.OutOfPockerValue);
            outOfPocket.Text = _viewModel.Summary.IsSome()
                           ? summary.OutOfPocket.Item.ToString("C2")
                           : "no out of pocket exists";

            var annualMaximum = FindViewById<TextView>(Resource.Id.AnualMaximumValue);
            annualMaximum.Text = _viewModel.Summary.IsSome()
                           ? summary.AnnualMaximum.Item.ToString("C2")
                           : "no annual maximum exists";

            var preventiveAndDiagnostic = FindViewById<TextView>(Resource.Id.PreventiveAndDiagnosticValue);
            preventiveAndDiagnostic.Text = _viewModel.Summary.IsSome()
                           ? $"{summary.NetworkCoverage.PreventiveAndDiagnostic.Item}%"
                           : "no preventive and diagnostic exists";

            var restoration = FindViewById<TextView>(Resource.Id.RestorationValue);
            restoration.Text = _viewModel.Summary.IsSome()
                           ? $"{summary.NetworkCoverage.Restoration.Item}%"
                           : "no restoration exists";

            var oralSurgery = FindViewById<TextView>(Resource.Id.OralSurgeryValue);
            oralSurgery.Text = _viewModel.Summary.IsSome()
                           ? $"{summary.NetworkCoverage.OralSurgery.Item}%"
                           : "no oral surgery exists";

            var periodontics = FindViewById<TextView>(Resource.Id.PeriodonticsValue);
            periodontics.Text = _viewModel.Summary.IsSome()
                           ? $"{summary.NetworkCoverage.Periodontics.Item}%"
                           : "no periodontics exists";

            //var timeline = _viewModel.Overview.Value.Coverage.Summary.Effective;

            //var effectiveFrom = FindViewById<TextView>(Resource.Id.EffectiveFromValue);
            //effectiveFrom.Text = $"{timeline.ActiveFrom.Item}";

            //var effectiveUntil = FindViewById<TextView>(Resource.Id.EffectiveUntilValue);
            //effectiveUntil.Text = $"{timeline.ActiveUntil.Item}";

            //var planCoverage = FindViewById<TextView>(Resource.Id.PlanCoverageValue);
            //planCoverage.Text = _viewModel.Overview.IsSome()
            //    ? _viewModel.Overview.Value.Coverage.Summary.PlanType.Item
            //    : "No plan found";

            //var network = FindViewById<TextView>(Resource.Id.NetworkValue);
            //network.Text = _viewModel.Overview.IsSome()
            //    ? _viewModel.Overview.Value.Coverage.Summary.NetworkName.Item
            //    : "No network found";

            //var groupNumber = FindViewById<TextView>(Resource.Id.GroupNumberValue);
            //groupNumber.Text = _viewModel.Overview.IsSome()
            //    ? _viewModel.Overview.Value.Coverage.Summary.GroupNumber.Item
            //    : "No group found";
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