using Android.Widget;
using ManageProviders;
using System.Collections.Generic;
using System.Linq;

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

            _viewModel.LoadSpecialties();
            _viewModel.LoadNetworks();
            _viewModel.LoadDistances();

            _specialtyListView = FindViewById<ListView>(Resource.Id.SpecialtyListView);
            LoadListView(_specialtyListView, Resource.Id.SpecialtyListView, Resource.Layout.SpecialtiesListItem, _viewModel.Specialty, _viewModel.Specialties);

            _networkListView = FindViewById<ListView>(Resource.Id.NetworkListView);
            LoadListView(_networkListView, Resource.Id.NetworkListView, Resource.Layout.NetworksListItem, _viewModel.Network, _viewModel.Networks);

            LoadDistances();

            ConfigureSearch();
        }

        void ConfigureSearch()
        {
            var search = FindViewById<Button>(Resource.Id.SearchProviders);
            search.Click += (s, e) =>
            {
                _viewModel.LoadProviders.Execute(null);
                var isValidated = _viewModel.ValidationResult.IsSuccess;

                if (isValidated)
                    _dispatcher.ViewProviders(_viewModel.Providers);
            };
        }

        void LoadListView(ListView listview, int listViewId, int listItemId, string selectedItem, IEnumerable<string> datasource)
        {
            listview = FindViewById<ListView>(listViewId);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.ItemClick += (s, e) => selectedItem = listview.GetItemIdAtPosition(e.Position).ToString();

            var items = datasource.ToArray();
            listview.Adapter = new ArrayAdapter<string>(this, listItemId, items);
        }

        void LoadDistances()
        {
            _distanceListView = FindViewById<ListView>(Resource.Id.DistanceListView);
            _distanceListView.ChoiceMode = ChoiceMode.Single;
            _distanceListView.ItemClick += (s, e) => _distanceListView.GetItemIdAtPosition(e.Position).ToString();

            var items = _viewModel.Distances.ToArray();
            _distanceListView.Adapter = new ArrayAdapter<int>(this, Resource.Layout.DistancesListItem, items);
        }
    }
}