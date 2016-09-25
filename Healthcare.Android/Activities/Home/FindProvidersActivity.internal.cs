using Android.Widget;
using ManageProviders;
using System.Collections.Generic;
using System.Linq;
using static MockProviders;

namespace Healthcare.Android
{
    partial class FindProvidersActivity
    {
        void MapNavigations() =>
            _dispatcher.ProvidersRequested += OnViewProvidersRequested;

        void UnMapNavigations() =>
            _dispatcher.ProvidersRequested -= OnViewProvidersRequested;

        void OnViewProvidersRequested(object sender, object e) =>
            StartActivity(typeof(ProvidersActivity));

        void MapCommands()
        {
            _viewModel = new ProvidersBySpecialtyViewModel(_memberId, _repository);

            _viewModel.Load();

            _specialtyListView = FindViewById<ListView>(Resource.Id.SpecialtyListView);
            LoadListView(_specialtyListView, Resource.Id.SpecialtyListView, Resource.Layout.SpecialtiesListItem, _viewModel.Specialties);

            _networkListView = FindViewById<ListView>(Resource.Id.NetworkListView);
            LoadListView(_networkListView, Resource.Id.NetworkListView, Resource.Layout.NetworksListItem, _viewModel.Networks);

            LoadDistances();

            _currentLocation = FindViewById<RadioButton>(Resource.Id.CurrentLocation);
            _currentLocation.CheckedChange += (s, e) => _viewModel.Location = SomeOtherLocation;

            _anotherAddress = FindViewById<RadioButton>(Resource.Id.AnotherAddress);
            _anotherAddress.CheckedChange += (s, e) => _viewModel.Location = SomeOtherLocation;

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

        void LoadListView(ListView listview, int listViewId, int listItemId, IEnumerable<string> datasource)
        {
            listview = FindViewById<ListView>(listViewId);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.ItemClick += (s, e) =>
                {
                    if (listview == _specialtyListView)
                        _viewModel.Specialty = listview.GetItemAtPosition(e.Position).ToString();

                    else if (listview == _networkListView)
                        _viewModel.Network = listview.GetItemAtPosition(e.Position).ToString();
                };

            var items = datasource.ToArray();
            listview.Adapter = new ArrayAdapter<string>(this, listItemId, items);
        }

        void LoadDistances()
        {
            _distanceListView = FindViewById<ListView>(Resource.Id.DistanceListView);
            _distanceListView.ChoiceMode = ChoiceMode.Single;
            _distanceListView.ItemClick += (s, e) =>
                {
                    var value = _distanceListView.GetItemAtPosition(e.Position);
                    _viewModel.Distance = int.Parse(value.ToString());
                };

            var items = _viewModel.Distances.ToArray();
            var adapter = new ArrayAdapter<int>(this, Android.Resource.Layout.DistancesListItem, items);
            _distanceListView.Adapter = adapter;
        }
    }
}