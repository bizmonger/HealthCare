using Home;
using InteractionLogic;
using Repositories;
using TestAPI;
using static Account;
using static MockMember;

namespace Healthcare.Android
{
    partial class ContactActivity
    {
        ContactViewModel _viewModel;
        MemberId _memberId = SomeMemberId;
        CompanyId _companyId = SomeCompanyId;
        Dispatcher _dispatcher = Global.Dispatcher;
        ICompanyRepository _companyRepository = new MockCompanyRepository();
        IClaimsRepository _claimsRepository = new MockClaimsRepository();
    }
}