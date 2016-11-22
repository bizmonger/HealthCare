using Android.Views;
using Android.Widget;
using static Healthcare.Android.Utility;

namespace Healthcare.Android.Adapters
{
    partial class FilesAdapter
    {
        static void UpdateUI(View view, string url)
        {
            var image = view.FindViewById<ImageView>(Resource.Id.fileImage);
            var imageBitmap = GetImageBitmapFromUrl(url);
            image.SetImageBitmap(imageBitmap);
        }
    }
}