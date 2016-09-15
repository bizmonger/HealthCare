using Android.Widget;
using ManageProviders;
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

            var specialty = FindViewById<ListView>(Resource.Id.SpecialtyListView);
            specialty.ItemSelected += (s, e) => _viewModel.Specialty = specialty.SelectedItem.ToString();

            var network = FindViewById<ListView>(Resource.Id.NetworkListView);
            network.ItemSelected += (s, e) => _viewModel.Network = network.SelectedItem.ToString();

            var distance = FindViewById<ListView>(Resource.Id.DistanceListView);
            distance.ItemSelected += (s, e) => _viewModel.Distance = int.Parse(distance.SelectedItem.ToString());

            var currentLocation = FindViewById<RadioButton>(Resource.Id.CurrentLocation);
            currentLocation.CheckedChange += (s, e) => _viewModel.Location = currentLocation.Checked ? CurrentLocation : SomeOtherLocation;

            var search = FindViewById<Button>(Resource.Id.SearchProviders);
            search.Click += (s, e) =>
            {
                _viewModel.LoadProviders.Execute(null);
                var isValidated = _viewModel.ValidationResult.IsSuccess;

                if (isValidated)
                    _dispatcher.ViewProviders(_viewModel.Providers);
            };
        }
    }
}