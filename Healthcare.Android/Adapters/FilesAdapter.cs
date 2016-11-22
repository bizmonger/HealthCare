using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using static Account;

namespace Healthcare.Android.Adapters
{
    partial class FilesAdapter : BaseAdapter<File>
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

            UpdateUI(view, @"http://www.freakingnews.com/pictures/57500/Mr-Bean-Drivers-License-57708.jpg");

            return view;
        }
    }
}