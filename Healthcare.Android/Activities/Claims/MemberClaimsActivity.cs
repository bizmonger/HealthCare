using Android.App;
using Android.OS;
using Android.Widget;
using Healthcare.Android.Adapters;
using static Claims;
using System.Collections.Generic;
using ManageClaims;
using static MockMember;

namespace Healthcare.Android
{
    [Activity(Label = nameof(MemberClaimsActivity))]
    partial class MemberClaimsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MemberClaims);
            Load();
        }

        void Load()
        {
            _viewModel = new MemberClaimsSummaryViewModel(SomeMemberId, _dispatcher, _repository);
            var listview = FindViewById<ListView>(Resource.Id.ClaimsListView);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.Adapter = new MemberClaimAdapter(this, new List<Claim>(_viewModel.Claims));
            listview.ItemClick += (s, e) => _viewModel.OnClaimSelected(listview.GetItemAtPosition(e.Position).Cast<Claim>());
        }
    }
}