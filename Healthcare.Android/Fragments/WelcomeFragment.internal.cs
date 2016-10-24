using Home;
using TestAPI;
using static MockMember;

namespace Healthcare.Android.Fragments
{
    partial class WelcomeFragment
    {
        readonly WelcomeViewModel _viewModel = new WelcomeViewModel(SomePatientId, new MockProfileRepository());
    }
}