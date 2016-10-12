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

        void PrepareViewModel()
        {
            var factory = new RepositoryFactory(Global.IsIntegrated);
            var repository = factory.CreateProfileRepository();

            if (repository.GetProfile(_memberId).IsSome())
            {
                var profile = repository.GetProfile(_memberId).Value;
                _viewModel = new IdCardViewModel(profile.IdCard, _dispatcher);
            }
        }
    }
}