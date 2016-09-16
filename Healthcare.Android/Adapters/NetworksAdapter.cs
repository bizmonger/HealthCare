using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using Android.App;

namespace Healthcare.Android.Adapters
{
    class NetworksAdapter : BaseAdapter<string>
    {
        readonly Activity _context;
        readonly List<string> _networks;

        public NetworksAdapter(Activity context, List<string> networks)
        {
            _context = context;
            _networks = networks;
        }

        public override string this[int position] => _networks[position];

        public override int Count => _networks.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.SpecialtiesListItem, null);
            var network = this[position];
            view.FindViewById<TextView>(Resource.Id.ProviderNetwork).Text = network;

            return view;
        }
    }
}