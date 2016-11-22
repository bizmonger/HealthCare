using Android.Widget;
using ManageAccount;

namespace Healthcare.Android
{
    partial class ProfileActivity
    {
        void CreateViewModel()
        {
            var factory = new DependencyFactory(Global.IsIntegrated);
            var PatientId = factory.GetPatientId();
            var repository = factory.CreateProfileRepository();

            _viewModel = new ProfileViewModel(PatientId, _dispatcher, repository);
            _viewModel.Load();
        }

        void UpdateUI()
        {
            var name = FindViewById<TextView>(Resource.Id.NameValue);
            name.Text = _viewModel.Profile.IsSome()
                        ? $"{_viewModel.Profile.Value.IdCard.Name.First} {_viewModel.Profile.Value.IdCard.Name.Last}"
                        : "need value";
        }        
    }
}