using Android.Widget;
using Healthcare.Android.Adapters;
using ManageProviders;
using System.Collections.Generic;
using static MockProviders;

namespace Healthcare.Android
{
    partial class FindProvidersActivity
    {
        void MapNavigations() =>
            _dispatcher.ViewProvidersRequested += OnViewProvidersRequested;

        void UnMapNavigations() =>
            _dispatcher.ViewProvidersRequested -= OnViewProvidersRequested;

        void OnViewProvidersRequested(object sender, object e) =>
            StartActivity(typeof(ProvidersActivity));

        void MapCommands()
        {
            _viewModel = new ProvidersBySpecialtyViewModel(_memberId, _repository);

            LoadSpecialties();
            LoadNetworks();
            LoadDistances();

            var search = FindViewById<Button>(Resource.Id.SearchProviders);
            search.Click += (s, e) =>
            {
                _viewModel.LoadProviders.Execute(null);
                var isValidated = _viewModel.ValidationResult.IsSuccess;

                if (isValidated)
                    _dispatcher.ViewProviders(_viewModel.Providers);
            };
        }

        void LoadSpecialties()
        {
            _specialtyListView = FindViewById<ListView>(Resource.Id.SpecialtyListView);
            _specialtyListView.ItemSelected += (s, e) => _viewModel.Specialty = _specialtyListView.SelectedItem.ToString();
            _viewModel.LoadSpecialties();
            _specialtyListView.Adapter = new SpecialtiesAdapter(this, new List<string>(_viewModel.Specialties));
        }

        void LoadNetworks()
        {
            _networkListView = FindViewById<ListView>(Resource.Id.NetworkListView);
            _networkListView.ItemSelected += (s, e) => _viewModel.Network = _networkListView.SelectedItem.ToString();
            _viewModel.LoadNetworks();
            _networkListView.Adapter = new NetworksAdapter(this, new List<string>(_viewModel.Networks));
        }

        void LoadDistances()
        {
            _distanceListView = FindViewById<ListView>(Resource.Id.DistanceListView);
            _distanceListView.ItemSelected += (s, e) => _viewModel.Distance = (int)_distanceListView.SelectedItem;
            _viewModel.LoadDistances();
            _distanceListView.Adapter = new DistancesAdapter(this, new List<int>(_viewModel.Distances));
        }
    }
}