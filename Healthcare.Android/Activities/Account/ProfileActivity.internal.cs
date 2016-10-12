using Android.Widget;
using ManageAccount;

namespace Healthcare.Android
{
    partial class ProfileActivity
    {
        void CreateViewModel()
        {
            var factory = new RepositoryFactory(Global.IsIntegrated);
            var memberId = factory.GetMemberId();
            var repository = factory.CreateProfileRepository();

            _viewModel = new ProfileViewModel(memberId, _diapatcher, repository);
            _viewModel.Load();
        }

        void UpdateUI()
        {
            var name = FindViewById<TextView>(Resource.Id.NameValue);
            name.Text = _viewModel.Profile.IsSome()
                        ? $"{_viewModel.Profile.Value.IdCard.Name.First} {_viewModel.Profile.Value.IdCard.Name.Last}"
                        : "need value";
        }
    }
}