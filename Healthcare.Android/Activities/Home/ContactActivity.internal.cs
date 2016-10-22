using Android.Widget;
using Home;

namespace Healthcare.Android
{
    partial class ContactActivity
    {
        void CreateViewModel()
        {
            var factory = new DependencyFactory(Global.IsIntegrated);
            var memberId = factory.GetMemberId();
            var companyRepository = factory.CreateCompanyRepository();
            var companyId = companyRepository.GetCompanyId(memberId);
            var claimsRepository = factory.CreateClaimsRepository();

            if (companyId.IsSome())
                _viewModel = new ContactViewModel(memberId, companyId.Value, _dispatcher, companyRepository, claimsRepository);
        }

        void Load()
        {
            _viewModel.Load();

            var phone = FindViewById<TextView>(Resource.Id.PhoneValue);
            phone.Text = _viewModel.Phone;

            var email = FindViewById<TextView>(Resource.Id.EmailValue);
            email.Text = _viewModel.Email;
        }
    }
}