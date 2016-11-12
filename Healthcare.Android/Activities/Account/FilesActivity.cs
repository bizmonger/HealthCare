using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = "Files")]
    partial class FilesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Files);
            CreateViewModel();
            LoadListView();
        }
    }
}