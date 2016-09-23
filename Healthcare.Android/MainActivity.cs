using Android.App;
using Android.OS;
using Home;

namespace Healthcare.Android
{
    [Activity(Label = "Healthcare.Android", MainLauncher = true, Icon = "@drawable/icon")]
    partial class MainActivity : Activity
    {
        public MainActivity()
        {
            _viewModel = new HomeViewModel(_dispatcher);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            MapCommands();
        }

        protected override void OnStart()
        {
            base.OnStart();
            MapNavigations();
        }

        protected override void OnStop()
        {
            base.OnStop();
            UnMapNavigations();
        }
    }
}