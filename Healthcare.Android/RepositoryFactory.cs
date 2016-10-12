using Repositories;
using TestAPI;
using static Account;
using static MockMember;

namespace Healthcare.Android
{
    class RepositoryFactory
    {
        readonly bool _isIntegration;

        public RepositoryFactory(bool isIntegration)
        {
            _isIntegration = isIntegration;
        }

        public MemberId GetMemberId() => _isIntegration ? GetActualMemberId() : SomeMemberId;
        static MemberId GetActualMemberId() => SomeMemberId; // TODO: Update with actual id retrieval

        public IBenefitsRepository CreateBenefitsRepository() =>
            !_isIntegration ? new MockBenefitsRepository() : null;

        public IClaimsRepository CreateClaimsRepository() =>
            !_isIntegration ? new MockClaimsRepository() : null;

        public IProfileRepository CreateProfileRepository() =>
            !_isIntegration ? new MockProfileRepository() : null;
    }
}