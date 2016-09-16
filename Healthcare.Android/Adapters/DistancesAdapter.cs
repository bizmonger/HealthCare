using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using Android.App;

namespace Healthcare.Android.Adapters
{
    class DistancesAdapter : BaseAdapter<int>
    {
        readonly Activity _context;
        readonly List<int> _distances;

        public DistancesAdapter(Activity context, List<int> distances)
        {
            _context = context;
            _distances = distances;
        }

        public override int this[int position] => _distances[position];

        public override int Count => _distances.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.DistancesListItem, null);
            var distance = this[position];
            view.FindViewById<TextView>(Resource.Id.ProviderDistance).Text = distance.ToString();

            return view;
        }
    }
}