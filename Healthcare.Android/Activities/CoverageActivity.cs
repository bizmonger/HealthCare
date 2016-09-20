using Android.App;
using Android.OS;
using Android.Widget;
using Healthcare.Android.Adapters;
using ManageBenefits;
using System.Collections.Generic;
using TestAPI;
using static Benefits;
using static MockMember;

namespace Healthcare.Android
{
    [Activity(Label = nameof(CoverageActivity), Icon = "@drawable/icon")]
    class CoverageActivity : Activity
    {
        CoverageViewModel _viewModel;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Coverage);

            _viewModel = new CoverageViewModel(SomeMemberId, new MockBenefitsRepository());
            LoadListView();
        }

        void LoadListView()
        {
            _viewModel.LoadCoverage();

            var listview = FindViewById<ListView>(Resource.Id.MemberCoverageListView);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.Adapter = new MemberCoverageAdapter(this, new List<MemberPlan>(_viewModel.MemberCoverages));
        }
    }
}