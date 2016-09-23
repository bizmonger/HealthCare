using Android.App;
using Android.OS;
using Home;
using InteractionLogic;

namespace Healthcare.Android
{
    [Activity(Label = "Healthcare.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public partial class MainActivity : Activity
    {
        readonly Dispatcher _dispatcher = Global.Dispatcher;
        readonly HomeViewModel _viewModel;

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