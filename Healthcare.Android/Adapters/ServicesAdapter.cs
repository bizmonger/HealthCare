using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace Healthcare.Android.Adapters
{
    class ServicesAdapter : BaseAdapter<Benefits.Service>
    {
        readonly Activity _context;
        readonly List<Benefits.Service> _services;

        public ServicesAdapter(Activity context, List<Benefits.Service> services)
        {
            _context = context;
            _services = services;
        }

        public override Benefits.Service this[int position] => _services[position];

        public override int Count => _services.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.ServicesListItem, null);

            var service = this[position];

            UpdateUI(view, service);

            return view;
        }

        static void UpdateUI(View view, Benefits.Service service)
        {
            var nameLabel = view.FindViewById<TextView>(Resource.Id.ServiceNameValue);
            nameLabel.Text = service.Name;

            var priceLabel = view.FindViewById<TextView>(Resource.Id.ServicePriceValue);
            priceLabel.Text = service.Price.ToString("C2");
        }
    }
}