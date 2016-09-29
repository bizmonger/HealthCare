using InteractionLogic;
using ManageBenefits;
using static Account;
using static MockMember;

namespace Healthcare.Android
{
    partial class PlanActivity
    {
        BenefitsPlanViewModel _viewModel;
        readonly Dispatcher _dispatcher = Global.Dispatcher;
        readonly MemberId _memberId = SomeMemberId;
    }
}