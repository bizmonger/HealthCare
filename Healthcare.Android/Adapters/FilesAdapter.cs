using Android.App;
using Android.Graphics;
using Android.Net;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using System.Net;
using static Account;

namespace Healthcare.Android.Adapters
{
    class FilesAdapter : BaseAdapter<File>
    {
        readonly Activity _context;
        readonly List<File> _files;

        public FilesAdapter(Activity context, List<File> files)
        {
            _context = context;
            _files = files;
        }

        public override File this[int position] => _files[position];

        public override int Count => _files.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.FileListItem, null);
            var file = this[position];

            UpdateUI(view, file);

            return view;
        }

        static Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

        static void UpdateUI(View view, File domainFile)
        {
            var image = view.FindViewById<ImageView>(Resource.Id.fileImage);

            using (var javaFile = new Java.IO.File(domainFile.Item))
                image.SetImageURI(Uri.FromFile(javaFile));

            var imageBitmap = GetImageBitmapFromUrl(@"http://www.freakingnews.com/pictures/57500/Mr-Bean-Drivers-License-57708.jpg");
            image.SetImageBitmap(imageBitmap);
        }
    }
}