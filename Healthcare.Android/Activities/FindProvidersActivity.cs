using System;
using Android.App;
using Android.OS;
using static Account;
using Android.Widget;
using Repositories;
using ManageProviders;
using static MockMember;
using TestAPI;

namespace Healthcare.Android
{
    [Activity(Label = nameof(FindProvidersActivity), Icon = "@drawable/icon")]
    class FindProvidersActivity : Activity
    {
        ProvidersBySpecialtyViewModel _viewModel;
        IProvidersRepository _repository = new MockProvidersRepository();
        MemberId _memberId = SomeMemberId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Benefits);

            MapNavigations();
            MapCommands();
        }

        void MapCommands()
        {
            _viewModel = new ProvidersBySpecialtyViewModel(_memberId, _repository);

            var specialty = FindViewById<ListView>(Resource.Id.SpecialtyListView);
            specialty.ItemSelected += (s, e) => _viewModel.Specialty = specialty.SelectedItem.ToString();

            var network = FindViewById<ListView>(Resource.Id.NetworkListView);
            network.ItemSelected += (s, e) => _viewModel.Network = network.SelectedItem.ToString();

            var distance = FindViewById<ListView>(Resource.Id.DistanceListView);
            distance.ItemSelected += (s, e) => _viewModel.Distance = int.Parse (distance.SelectedItem.ToString());

            var search = FindViewById<ListView>(Resource.Id.SearchProviders);
            search.Click += (s, e) => _viewModel.LoadProviders.Execute(null);
        }

        void MapNavigations()
        {
            throw new NotImplementedException();
        }
    }
}