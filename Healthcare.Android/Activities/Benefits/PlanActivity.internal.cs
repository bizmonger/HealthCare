using Android.Widget;
using ManageBenefits;

namespace Healthcare.Android
{
    partial class PlanActivity
    {
        void Load()
        {
            _viewModel = new BenefitsPlanViewModel(_memberId , _dispatcher);
            var planName = FindViewById<TextView>(Resource.Id.PlanName);
            planName.Text = "need value";

            var planHighlights = FindViewById<TextView>(Resource.Id.PlanHighlights);
            planHighlights.Text = "need value";

            var deductable = FindViewById<TextView>(Resource.Id.DeductableValue);
            deductable.Text = "need value";

            var outOfPocket = FindViewById<TextView>(Resource.Id.OutOfPockerValue);
            outOfPocket.Text = "need value";

            var annualMaximum = FindViewById<TextView>(Resource.Id.AnualMaximumValue);
            annualMaximum.Text = "need value";

            var networkBenefits = FindViewById<TextView>(Resource.Id.NetworkBenefitsValue);
            networkBenefits.Text = "need value";

            var preventiveAndDiagnostic = FindViewById<TextView>(Resource.Id.PreventiveAndDiagnosticValue);
            preventiveAndDiagnostic.Text = "need value";

            var restoration = FindViewById<TextView>(Resource.Id.RestorationValue);
            restoration.Text = "need value";

            var oralSurgery = FindViewById<TextView>(Resource.Id.OralSurgeryValue);
            oralSurgery.Text = "need value";

            var periodontics = FindViewById<TextView>(Resource.Id.PeriodonticsValue);
            periodontics.Text = "need value";
        }
    }
}