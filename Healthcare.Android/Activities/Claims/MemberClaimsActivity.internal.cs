using ManageClaims;
using Android.Widget;
using Healthcare.Android.Adapters;
using static Claims;
using System.Collections.Generic;
using static MockMember;

namespace Healthcare.Android
{
    partial class MemberClaimsActivity
    {
        void Load()
        {
            _viewModel = new MemberClaimsSummaryViewModel(SomeMemberId, _dispatcher, _repository);
            _viewModel.Load();

            var listview = FindViewById<ListView>(Resource.Id.ClaimsListView);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.Adapter = new MemberClaimAdapter(this, new List<Claim>(_viewModel.Claims));
            listview.ItemClick += (s, e) => _viewModel.OnClaimSelected(listview.GetItemAtPosition(e.Position).Cast<Claim>());
        }
    }
}