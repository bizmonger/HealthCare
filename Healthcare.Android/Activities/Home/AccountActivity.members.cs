using InteractionLogic;
using ManageAccount;
using static Account;
using static MockMember;

namespace Healthcare.Android
{
    partial class AccountActivity
    {
        AccountViewModel _viewModel;
        Dispatcher _dispatcher = Global.Dispatcher;
        MemberId _memberId = SomeMemberId;
    }
}