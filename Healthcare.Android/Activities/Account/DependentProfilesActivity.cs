using Android.App;
using Android.OS;
using Android.Widget;
using Healthcare.Android.Adapters;
using ManageAccount;
using System.Collections.Generic;
using TestAPI;
using static Account;
using static MockMember;

namespace Healthcare.Android
{
    [Activity(Label = nameof(DependentProfilesActivity))]
    public class DependentProfilesActivity : Activity
    {
        DependentProfilesViewModel _viewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DependentProfiles);
            LoadListView();
        }

        void LoadListView()
        {
            _viewModel = new DependentProfilesViewModel(new MockProfileRepository(), SomeMemberId);
            _viewModel.Load();

            var listview = FindViewById<ListView>(Resource.Id.Dependents);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.Adapter = new MemberProfileAdapter(this, new List<Profile>(_viewModel.Dependents));
        }
    }
}