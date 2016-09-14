using InteractionLogic;
using ManageBenefits;
using Repositories;
using TestAPI;
using static Account;
using static MockMember;

namespace Healthcare.Android
{
    partial class BenefitsActivity
    {
        IBenefitsRepository _repository = new MockBenefitsRepository();
        BenefitsOverviewViewModel _viewModel;
        readonly Dispatcher _dispatcher = Global.Dispatcher;
        IdCard _account = SomeIdCard;
    }
}