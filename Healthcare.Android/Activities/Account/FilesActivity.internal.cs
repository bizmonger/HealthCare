using Android.Widget;
using Healthcare.Android.Adapters;
using ManageAccount;
using System.Collections.Generic;
using static Account;

namespace Healthcare.Android
{
    partial class FilesActivity
    {
        void CreateViewModel()
        {
            var factory = new DependencyFactory(Global.IsIntegrated);
            var repository = factory.CreateProfileRepository();
            var patientId = factory.GetPatientId();

            if (repository.GetProfile(patientId).IsSome())
            {
                var profile = repository.GetProfile(patientId).Value;
                _viewModel = new FilesViewModel(patientId, Global.Dispatcher, repository);
            }
        }

        void LoadListView()
        {
            _viewModel.Load();

            var listview = FindViewById<ListView>(Resource.Id.Dependents);
            listview.ChoiceMode = ChoiceMode.Single;
            listview.Adapter = new FilesAdapter(this, new List<File>(_viewModel.Files));
            listview.ItemClick += (s, e) => _viewModel.OnFileSelected(listview.GetItemAtPosition(e.Position).Cast<File>());
        }
    }
}