using Android.App;
using Android.OS;
using Android.Views;

namespace Healthcare.Android
{
    [Activity(Label = "Account")]
    partial class AccountActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Account);
            CreateViewModel();
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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.AccountMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.Profile:
                    {
                        _viewModel.ViewProfile.Execute(null);
                        return true;
                    }
                    
                case Resource.Id.Dependents:
                    {
                        _viewModel.ViewDependentProfiles.Execute(null);
                        return true;
                    }

                case Resource.Id.Settings:
                    {
                        _viewModel.ViewLoginSettings.Execute(null);
                        return true;
                    }
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}