using Android.App;
using Android.Net;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
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

        static void UpdateUI(View view, File domainFile)
        {
            var image = view.FindViewById<ImageView>(Resource.Id.fileImage);
            using (var javaFile = new Java.IO.File(domainFile.Item))
            {
                image.SetImageURI(Uri.FromFile(javaFile));
            }
        }
    }
}