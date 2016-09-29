using Android.Widget;
using Home;

namespace Healthcare.Android
{
    partial class ContactActivity
    {
        void Load()
        {
            _viewModel = new ContactViewModel(_memberId, _companyId, _dispatcher, _companyRepository, _claimsRepository);
            _viewModel.Load();

            var phone = FindViewById<TextView>(Resource.Id.PhoneValue);
            phone.Text = _viewModel.Phone.Item;

            var email = FindViewById<TextView>(Resource.Id.Email);
            email.Text = _viewModel.Email.Item;
        }
    }
}