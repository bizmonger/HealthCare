using Android.Widget;
using Healthcare.Android.Adapters;
using ManageBenefits;
using System.Collections.Generic;

namespace Healthcare.Android
{
    partial class PlanActivity
    {
        void LoadListView()
        {
            _viewModel.Load();

            var listview = FindViewById<ListView>(Resource.Id.MemberCoverageListView);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.Adapter = new ServicesAdapter(this, new List<Benefits.Service>(_viewModel.Services));
        }

        void CreateViewModel()
        {
            var factory = new DependencyFactory(Global.IsIntegrated);
            var companyId = factory.GetCompanyId();
            var patientId = factory.GetPatientId();
            var repository = factory.CreateBenefitsRepository();

            _viewModel = new BenefitsPlanViewModel(companyId, patientId, _dispatcher, repository);
        }
    }
}