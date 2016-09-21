using Android.App;
using Android.OS;
using ManageClaims;
using static MockMember;
using TestAPI;
using Android.Widget;
using System.Linq;

namespace Healthcare.Android
{
    [Activity(Label = nameof(ClaimsActivity))]
    public class ClaimsActivity : Activity
    {
        ClaimsSummaryViewModel _viewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Claims);

            Load();
        }

        void Load()
        {
            _viewModel = new ClaimsSummaryViewModel(SomeMemberId, new MockClaimsRepository());
            _viewModel.LoadFamilySummary();
            _viewModel.LoadMemberSummaries();

            var familySummary = FindViewById<TextView>(Resource.Id.FamilySummaryValue);
            familySummary.Text = _viewModel.FamilySummary.Claims.Count().ToString();

            var providersCharged = FindViewById<TextView>(Resource.Id.ProvidersChargedValue);
            providersCharged.Text = _viewModel.FamilySummary.ProvidersCharged.Item.ToString("C2");

            var insuranceSavings = FindViewById<TextView>(Resource.Id.InsuranceSavedYouValue);
            insuranceSavings.Text = _viewModel.FamilySummary.InsuranceSavings.Item.ToString("C2");

            var totalSavings = FindViewById<TextView>(Resource.Id.SavingValue);
            totalSavings.Text = $"{ _viewModel.FamilySummary.TotalSavings().ToString()}%";
        }
    }
}