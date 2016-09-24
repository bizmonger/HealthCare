using Android.Widget;
using Healthcare.Android.Adapters;
using System.Collections.Generic;
using static Benefits;

namespace Healthcare.Android
{
    partial class CoverageActivity
    {
        void LoadListView()
        {
            _viewModel.LoadCoverage();

            var listview = FindViewById<ListView>(Resource.Id.MemberCoverageListView);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.Adapter = new MemberCoverageAdapter(this, new List<MemberPlan>(_viewModel.MemberCoverages));
        }
    }
}