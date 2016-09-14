using Android.Widget;
using ManageAccount;

namespace Healthcare.Android
{
    partial class IdCardActivity
    {
        void MapCommands()
        {
            _viewModel = new IdCardViewModel(_idCard, _dispatcher);

            var print = FindViewById<Button>(Resource.Id.Print);
            print.Click += (s, e) => _viewModel.Print.Execute(null);

            var email = FindViewById<Button>(Resource.Id.Email);
            email.Click += (s, e) => _viewModel.Email.Execute(null);

            var enableHomeAccess = FindViewById<Button>(Resource.Id.EnableIdViewing);
            enableHomeAccess.Click += (s, e) => _viewModel.EnableHomeAccess.Execute(null);
        }
    }
}