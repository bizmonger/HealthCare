using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Healthcare.Android.Fragments
{
    partial class WelcomeFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _viewModel.Load();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) =>
            inflater.Inflate(Resource.Layout.WelcomeFragment, container, false);

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            var name = _viewModel.Profile.IsSome() ? _viewModel.Profile.Value.IdCard.Name : null;

            var welcomeLabel = View.FindViewById<TextView>(Resource.Id.Welcome);
            welcomeLabel.Text = $"Welcome {name.First}";

            var lastCleaningLabel = View.FindViewById<TextView>(Resource.Id.LastCleaningValue);

            lastCleaningLabel.Text = _viewModel.LastCleaning.IsSome()
                ? $"{_viewModel.LastCleaning.Value.ToShortDateString()}"
                : "No history";

            var lastVisit = View.FindViewById<TextView>(Resource.Id.LastDentalVisitValue);
            lastVisit.Text = _viewModel.LastVisit.IsSome()
                ? $"{_viewModel.LastVisit.Value.ToShortDateString()}"
                : "No history";
        }
    }
}