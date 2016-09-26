using Android.App;
using Android.OS;
using ManageBenefits;
using TestAPI;
using static MockMember;

namespace Healthcare.Android
{
    [Activity(Label = "Coverage", Icon = "@drawable/icon")]
    partial class CoverageActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Coverage);

            _viewModel = new CoverageViewModel(SomeMemberId, new MockBenefitsRepository());
            LoadListView();
        }
    }
}