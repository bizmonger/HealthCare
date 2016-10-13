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

        public MemberId GetMemberId() => _isIntegration ? GetActualMemberId() : SomeMemberId;
        static MemberId GetActualMemberId() => SomeMemberId; // TODO: Update with actual id retrieval

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