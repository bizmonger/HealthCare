using Repositories;
using TestAPI;
using static Account;
using static MockMember;

namespace Healthcare.Android
{
    class DependencyFactory
    {
        readonly bool _isIntegration;

        public DependencyFactory(bool isIntegration)
        {
            _isIntegration = isIntegration;
        }

        public PatientId GetPatientId() => _isIntegration ? GetActualPatientId() : SomePatientId;
        static PatientId GetActualPatientId() => SomePatientId; // TODO: Update with actual id retrieval

        public IBenefitsRepository CreateBenefitsRepository() =>
            !_isIntegration ? new MockBenefitsRepository() : null;

        public IClaimsRepository CreateClaimsRepository() =>
            !_isIntegration ? new MockClaimsRepository() : null;

        public ICompanyRepository CreateCompanyRepository() =>
            !_isIntegration ? new MockCompanyRepository() : null;

        public IProfileRepository CreateProfileRepository() =>
            !_isIntegration ? new MockProfileRepository() : null;
    }
}