using Android.Widget;
using Healthcare.Android.Adapters;
using ManageBenefits;
using System.Collections.Generic;
using static Benefits;

namespace Healthcare.Android
{
    partial class PlanActivity
    {
        void LoadListView()
        {
            _viewModel.Load();

            var listview = FindViewById<ListView>(Resource.Id.MemberCoverageListView);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.Adapter = new MemberCoverageAdapter(this, new List<MemberPlan>(_viewModel.Members));
        }

        void CreateViewModel()
        {
            var factory = new DependencyFactory(Global.IsIntegrated);
            var PatientId = factory.GetPatientId();
            var repository = factory.CreateBenefitsRepository();

            _viewModel = new BenefitsPlanViewModel(PatientId, _dispatcher, repository);
        }
    }
}