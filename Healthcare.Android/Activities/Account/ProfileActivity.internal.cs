using Android.Widget;

namespace Healthcare.Android
{
    partial class ProfileActivity
    {
        void UpdateUI()
        {
            var name = FindViewById<TextView>(Resource.Id.NameValue);
            name.Text = "need value"; // _viewModel.Profile.Name;
        }
    }
}