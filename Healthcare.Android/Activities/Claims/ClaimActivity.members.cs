using InteractionLogic;
using ManageClaims;
using Repositories;
using TestAPI;

namespace Healthcare.Android
{
    partial class ClaimDetailActivity
    {
        ClaimsDetailViewModel _viewModel;
        readonly Dispatcher _dispatcher = Global.Dispatcher;
        IClaimsRepository _repository = new MockClaimsRepository();
    }
}