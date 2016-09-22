using ManageClaims;
using InteractionLogic;
using TestAPI;
using Repositories;

namespace Healthcare.Android
{
    partial class MemberClaimsActivity
    {
        MemberClaimsSummaryViewModel _viewModel;
        Dispatcher _dispatcher = Global.Dispatcher;
        readonly IClaimsRepository _repository = new MockClaimsRepository();
    }
}