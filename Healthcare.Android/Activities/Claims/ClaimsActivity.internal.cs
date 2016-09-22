using ManageClaims;
using TestAPI;
using static MockMember;
using Android.Widget;
using Healthcare.Android.Adapters;
using System.Collections.Generic;
using static Claims;

namespace Healthcare.Android
{
    partial class ClaimsActivity
    {
        void Load()
        {
            _viewModel = new ClaimsSummaryViewModel(SomeMemberId, _dispatcher, new MockClaimsRepository());
            _viewModel.Load();

            //var familySummary = FindViewById<TextView>(Resource.Id.FamilySummaryValue);
            //if (_viewModel.FamilySummary.IsSome())
            //{

            //}

            //familySummary.Text = _viewModel.FamilySummary.Claims.Count().ToString();

            //var providersCharged = FindViewById<TextView>(Resource.Id.ProvidersChargedValue);
            //providersCharged.Text = _viewModel.FamilySummary.ProvidersCharged.Item.ToString("C2");

            //var insuranceSavings = FindViewById<TextView>(Resource.Id.InsuranceSavedYouValue);
            //insuranceSavings.Text = _viewModel.FamilySummary.InsuranceSavings.Item.ToString("C2");

            //var totalSavings = FindViewById<TextView>(Resource.Id.SavingValue);
            //totalSavings.Text = $"{ _viewModel.FamilySummary.TotalSavings().ToString()}%";

            var listview = FindViewById<ListView>(Resource.Id.MemberClaimsListView);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.Adapter = new ClaimSummaryAdapter(this, new List<ClaimsSummary>(_viewModel.DependentSummaries));
            listview.ItemClick += (s, e) => _viewModel.OnSummarySelected(listview.GetItemAtPosition(e.Position).Cast<ClaimsSummary>());
        }
    }
}