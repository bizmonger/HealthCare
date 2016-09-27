using Home;
using InteractionLogic;
using Repositories;
using TestAPI;
using static Account;
using static MockMember;

namespace Healthcare.Android
{
    partial class PortalDashboardActivity
    {
        PortalViewModel _viewModel;
        Dispatcher _dispatcher = Global.Dispatcher;
        MemberId _memberId = SomeMemberId;
        IBenefitsRepository _repository = new MockBenefitsRepository();
    }
}