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
            var factory = new RepositoryFactory(Global.IsIntegrated);
            var memberId = factory.GetMemberId();
            var repository = factory.CreateBenefitsRepository();

            _viewModel = new CoverageViewModel(memberId, repository);
        }

        void LoadListView()
        {
            _viewModel.Load();

            var listview = FindViewById<ListView>(Resource.Id.MemberCoverageListView);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.Adapter = new MemberCoverageAdapter(this, new List<MemberPlan>(_viewModel.MemberCoverages));
        }
    }
}