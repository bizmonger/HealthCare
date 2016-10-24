using Android.Widget;
using Home;

namespace Healthcare.Android
{
    partial class ContactActivity
    {
        void CreateViewModel()
        {
            var factory = new DependencyFactory(Global.IsIntegrated);
            var PatientId = factory.GetPatientId();
            var companyRepository = factory.CreateCompanyRepository();
            var companyId = companyRepository.GetCompanyId(PatientId);
            var claimsRepository = factory.CreateClaimsRepository();

            if (companyId.IsSome())
                _viewModel = new ContactViewModel(PatientId, companyId.Value, _dispatcher, companyRepository, claimsRepository);
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