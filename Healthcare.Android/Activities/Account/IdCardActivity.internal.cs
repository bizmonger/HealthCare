using Android.Widget;
using ManageAccount;

namespace Healthcare.Android
{
    partial class IdCardActivity
    {
        void MapCommands()
        {
            var print = FindViewById<Button>(Resource.Id.Print);
            print.Click += (s, e) => _viewModel.Print.Execute(null);

            var email = FindViewById<Button>(Resource.Id.Email);
            email.Click += (s, e) => _viewModel.Email.Execute(null);

            var enableHomeAccess = FindViewById<Button>(Resource.Id.EnableIdViewing);
            enableHomeAccess.Click += (s, e) => _viewModel.EnableHomeAccess.Execute(null);
        }

        void CreateViewModel()
        {
            var factory = new DependencyFactory(Global.IsIntegrated);
            var repository = factory.CreateProfileRepository();
            var patientId = factory.GetPatientId();

            if (repository.GetProfile(patientId).IsSome())
            {
                var profile = repository.GetProfile(patientId).Value;
                _viewModel = new IdCardViewModel(profile.IdCard, _dispatcher);
            }
        }

        void Load()
        {
            
        }
    }
}