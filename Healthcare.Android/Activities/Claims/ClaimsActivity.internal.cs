using Android.Widget;
using Healthcare.Android.Adapters;
using ManageClaims;
using System.Collections.Generic;
using System.Linq;
using TestAPI;
using static Claims;
using static MockMember;

namespace Healthcare.Android
{
    partial class ClaimsActivity
    {
        void MapNavigations() =>
            _dispatcher.MemberClaimsRequested += OnMemberClaimsRequested;

        void UnMapNavigations() =>
            _dispatcher.MemberClaimsRequested -= OnMemberClaimsRequested;

        void OnMemberClaimsRequested(object sender, object e) =>
            StartActivity(typeof(MemberClaimsActivity));

        void Load()
        {
            _viewModel = new ClaimsSummaryViewModel(SomeMemberId, _dispatcher, new MockClaimsRepository());
            _viewModel.Load();

            var familySummary = FindViewById<TextView>(Resource.Id.FamilySummaryValue);
            familySummary.Text = _viewModel.FamilySummary.IsSome()
                ? _viewModel.FamilySummary.Value.Claims.Count().ToString()
                : string.Empty;

            var providersCharged = FindViewById<TextView>(Resource.Id.ProvidersChargedValue);
            providersCharged.Text = _viewModel.FamilySummary.IsSome()
                ? _viewModel.FamilySummary.Value.ProvidersCharged.Item.ToString("C2")
                : string.Empty;

            var insuranceSavings = FindViewById<TextView>(Resource.Id.InsuranceSavedYouValue);
            insuranceSavings.Text = _viewModel.FamilySummary.IsSome()
                ? _viewModel.FamilySummary.Value.InsuranceSavings.Item.ToString("C2")
                : string.Empty;

            var totalSavings = FindViewById<TextView>(Resource.Id.SavingValue);
            totalSavings.Text = _viewModel.FamilySummary.IsSome()
                ? $"{ _viewModel.FamilySummary.Value.TotalSavings().ToString()}%"
                : string.Empty;

            var listview = FindViewById<ListView>(Resource.Id.MemberClaimsListView);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.Adapter = new ClaimSummaryAdapter(this, new List<ClaimsSummary>(_viewModel.DependentSummaries));


            listview.ItemClick += (s, e) =>
                {
                    var item = listview.GetItemAtPosition(e.Position).Cast<ClaimsSummary>();
                    _viewModel.SetDependentSummary(item);
                    _viewModel.ViewClaims.Execute(null);
                };
        }
    }
}