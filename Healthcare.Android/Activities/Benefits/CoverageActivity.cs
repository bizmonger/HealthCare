using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = "Coverage", Icon = "@drawable/icon")]
    partial class CoverageActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Coverage);

            CreateViewModel();
            LoadListView();
        }
    }
}