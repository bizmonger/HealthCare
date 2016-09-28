using Android.Widget;
using Healthcare.Android.Adapters;
using ManageClaims;
using System.Collections.Generic;
using System.Linq;
using static Claims;
using static MockMember;

namespace Healthcare.Android
{
    partial class MemberClaimsActivity
    {
        void Load()
        {
            _viewModel = new MemberClaimsSummaryViewModel(SomeMemberId, _dispatcher, _repository);
            _viewModel.Load();

            var memberSummary = FindViewById<TextView>(Resource.Id.MemberSummaryValue);
            memberSummary.Text = _viewModel.Summary.IsSome()
                ? _viewModel.Summary.Value.Claims.Count().ToString()
                : "";

            var memberProvidersCharged = FindViewById<TextView>(Resource.Id.MemberProvidersChargedValue);
            memberProvidersCharged.Text = _viewModel.Summary.IsSome()
                ? _viewModel.Summary.Value.ProvidersCharged.Item.ToString("C2")
                : "";

            var MemberInsuranceSavedYou = FindViewById<TextView>(Resource.Id.MemberInsuranceSavedYouValue);
            MemberInsuranceSavedYou.Text = _viewModel.Summary.IsSome()
                ? _viewModel.Summary.Value.InsuranceSavings.Item.ToString("C2")
                : "";

            var memberSaving = FindViewById<TextView>(Resource.Id.MemberSavingValue);
            memberSaving.Text = _viewModel.Summary.IsSome()
                ? _viewModel.Summary.Value.TotalSavings().ToString("C2")
                : "";

            var listview = FindViewById<ListView>(Resource.Id.ClaimsListView);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.Adapter = new MemberClaimAdapter(this, new List<Claim>(_viewModel.Claims));
            listview.ItemClick += (s, e) => _viewModel.OnClaimSelected(listview.GetItemAtPosition(e.Position).Cast<Claim>());
        }
    }
}