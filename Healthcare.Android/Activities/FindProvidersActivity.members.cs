using InteractionLogic;
using ManageProviders;
using Repositories;
using TestAPI;
using static Account;
using static MockMember;

namespace Healthcare.Android
{
    partial class FindProvidersActivity
    {
        ProvidersBySpecialtyViewModel _viewModel;
        readonly IProvidersRepository _repository = new MockProvidersRepository();
        readonly MemberId _memberId = SomeMemberId;
        readonly Dispatcher _dispatcher = Global.Dispatcher;
    }
}