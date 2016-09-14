using Home;
using InteractionLogic;
using Repositories;
using static Account;
using TestAPI;
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