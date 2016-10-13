using Android.App;
using Android.OS;
using Android.Views;
using static MockMember;

namespace Healthcare.Android
{
    [Activity(Label = "Company X")]
    partial class PortalDashboardActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PortalDashboard);
            CreateViewModel();
            MapCommands();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.HomeMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.Account:
                    {
                        _dispatcher.ViewAccount(SomeMemberId);
                        return true;
                    }
            }

            return base.OnOptionsItemSelected(item);
        }

        protected override void OnStop()
        {
            base.OnStop();
            UnMapNavigations();
        }

        protected override void OnStart()
        {
            base.OnStart();
            MapNavigations();
        }
    }
}