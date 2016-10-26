using Android.Widget;
using Healthcare.Android.Adapters;
using ManageBenefits;
using System.Collections.Generic;
using static Benefits;

namespace Healthcare.Android
{
    partial class CoverageActivity
    {
        void CreateViewModel()
        {
            var factory = new DependencyFactory(Global.IsIntegrated);
            var companyId = factory.GetCompanyId();
            var patientId = factory.GetPatientId();
            var repository = factory.CreateBenefitsRepository();

            _viewModel = new CoverageViewModel(companyId, patientId, repository);
        }

        void LoadListView()
        {
            _viewModel.Load();

            var listview = FindViewById<ListView>(Resource.Id.ServicesListView);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.Adapter = new ServicesAdapter(this, new List<Service>(_viewModel.Services));
        }
    }
}