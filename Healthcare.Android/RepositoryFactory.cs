using Repositories;
using TestAPI;

namespace Healthcare.Android
{
    class RepositoryFactory
    {
        readonly bool _isIntegration;

        public RepositoryFactory(bool isIntegration)
        {
            _isIntegration = isIntegration;
        }

        public IBenefitsRepository CreateBenefitsRepository() =>
            !_isIntegration ? new MockBenefitsRepository() : null;

        public IProfileRepository CreateProfileRepository() =>
            !_isIntegration ? new MockProfileRepository() : null;
    }
}