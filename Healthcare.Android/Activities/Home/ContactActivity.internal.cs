using Android.Widget;
using Home;

namespace Healthcare.Android
{
    partial class ContactActivity
    {
        void CreateViewModel()
        {
            var factory = new RepositoryFactory(Global.IsIntegrated);
            var memberId = factory.GetMemberId();
            var companyRepository = factory.CreateCompanyRepository();
            var companyId = companyRepository.GetCompanyId(memberId);
            var claimsRepository = factory.CreateClaimsRepository();

            _viewModel = new ContactViewModel(memberId, companyId, _dispatcher, companyRepository, claimsRepository);
        }

        void Load()
        {
            _viewModel.Load();

            var phone = FindViewById<TextView>(Resource.Id.PhoneValue);
            phone.Text = _viewModel.Phone.Item;

            var email = FindViewById<TextView>(Resource.Id.EmailValue);
            email.Text = _viewModel.Email.Item;
        }
    }
}