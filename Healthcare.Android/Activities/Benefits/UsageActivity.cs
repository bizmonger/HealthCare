using Android.App;
using Android.OS;
using Android.Widget;
using Healthcare.Android.Adapters;
using ManageBenefits;
using System.Collections.Generic;
using TestAPI;
using static Benefits;

namespace Healthcare.Android
{
    [Activity(Label = "Usage", Icon = "@drawable/icon")]
    class UsageActivity : Activity
    {
        BenefitsUsageViewModel _viewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Usage);

            var factory = new DependencyFactory(Global.IsIntegrated);
            var patientId = factory.GetPatientId();

            _viewModel = new BenefitsUsageViewModel(patientId, new MockBenefitsRepository());
            _viewModel.Load();

            var listview = FindViewById<ListView>(Resource.Id.MemberUsageListView);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.Adapter = new MemberCoverageAdapter(this, new List<MemberPlan>(_viewModel.Members));
        }
    }
}