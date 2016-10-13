using Android.Widget;
using Healthcare.Android.Adapters;
using ManageAccount;
using System.Collections.Generic;
using TestAPI;
using static Account;

namespace Healthcare.Android
{
    partial class DependentProfilesActivity
    {
        void MapNavigations() => _dispatcher.ProfileRequested += OnProfileRequested;
        void UnMapNavigations() => _dispatcher.ProfileRequested -= OnProfileRequested;

        void OnProfileRequested(object sender, object e) => StartActivity(typeof(ProfileActivity));

        void CreateViewModel()
        {
            var factory = new DependencyFactory(Global.IsIntegrated);
            var memberId = factory.GetMemberId();
            _viewModel = new DependentProfilesViewModel(memberId, _dispatcher, new MockProfileRepository());
        }

        void LoadListView()
        {
            _viewModel.Load();

            var listview = FindViewById<ListView>(Resource.Id.Dependents);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.Adapter = new MemberProfileAdapter(this, new List<Profile>(_viewModel.Dependents));
            listview.ItemClick += (s, e) => _viewModel.OnProfileSelected(listview.GetItemAtPosition(e.Position).Cast<Profile>());
        }
    }
}