
using Android.App;
using Android.OS;

namespace Healthcare.Android
{
    [Activity(Label = "Files")]
    public class FilesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Files);
        }
    }
}