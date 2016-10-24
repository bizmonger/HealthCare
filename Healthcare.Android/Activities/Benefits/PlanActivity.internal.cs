//using Android.Widget;
//using ManageBenefits;

//namespace Healthcare.Android
//{
//    partial class PlanActivity
//    {
//        void Load()
//        {
//            _viewModel.Load();
//            var summary = _viewModel.Summary.Value;

//            var planName = FindViewById<TextView>(Resource.Id.PlanName);
//            planName.Text = _viewModel.Summary.IsSome()
//                           ? summary.PlanType.Item
//                           : "no plan exists";

//            var deductable = FindViewById<TextView>(Resource.Id.DeductableValue);
//            deductable.Text = _viewModel.Summary.IsSome()
//                           ? summary.Deductable.Total.ToString("C2")
//                           : "no deductable exists";

//            var outOfPocket = FindViewById<TextView>(Resource.Id.OutOfPockerValue);
//            outOfPocket.Text = _viewModel.Summary.IsSome()
//                           ? summary.OutOfPocket.Item.ToString("C2")
//                           : "no out of pocket exists";

//            var annualMaximum = FindViewById<TextView>(Resource.Id.AnualMaximumValue);
//            annualMaximum.Text = _viewModel.Summary.IsSome()
//                           ? summary.AnnualMaximum.Item.ToString("C2")
//                           : "no annual maximum exists";

//            var preventiveAndDiagnostic = FindViewById<TextView>(Resource.Id.PreventiveAndDiagnosticValue);
//            preventiveAndDiagnostic.Text = _viewModel.Summary.IsSome()
//                           ? $"{summary.NetworkCoverage.PreventiveAndDiagnostic.Item}%"
//                           : "no preventive and diagnostic exists";

//            var restoration = FindViewById<TextView>(Resource.Id.RestorationValue);
//            restoration.Text = _viewModel.Summary.IsSome()
//                           ? $"{summary.NetworkCoverage.Restoration.Item}%"
//                           : "no restoration exists";

//            var oralSurgery = FindViewById<TextView>(Resource.Id.OralSurgeryValue);
//            oralSurgery.Text = _viewModel.Summary.IsSome()
//                           ? $"{summary.NetworkCoverage.OralSurgery.Item}%"
//                           : "no oral surgery exists";

//            var periodontics = FindViewById<TextView>(Resource.Id.PeriodonticsValue);
//            periodontics.Text = _viewModel.Summary.IsSome()
//                           ? $"{summary.NetworkCoverage.Periodontics.Item}%"
//                           : "no periodontics exists";
//        }

//        void CreateViewModel()
//        {
//            var factory = new DependencyFactory(Global.IsIntegrated);
//            var PatientId = factory.GetPatientId();
//            var repository = factory.CreateBenefitsRepository();

//            _viewModel = new BenefitsPlanViewModel(PatientId, _dispatcher, repository);
//        }
//    }
//}