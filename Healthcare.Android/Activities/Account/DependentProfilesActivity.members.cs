using InteractionLogic;
using ManageAccount;
using static Account;

namespace Healthcare.Android
{
    partial class DependentProfilesActivity
    {
        DependentProfilesViewModel _viewModel;
        Dispatcher _dispatcher = Global.Dispatcher;
        MemberId _memberId;
    }
}