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

        IBenefitsRepository CreateBenefitsRepository() =>
            !_isIntegration ? new MockBenefitsRepository() : null;
    }
}