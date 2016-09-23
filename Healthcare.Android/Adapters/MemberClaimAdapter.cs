using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using static Claims;

namespace Healthcare.Android.Adapters
{
    class MemberClaimAdapter : BaseAdapter<Claim>
    {
        readonly Activity _context;
        readonly List<Claim> _claims;

        public MemberClaimAdapter(Activity context, List<Claim> claims)
        {
            _context = context;
            _claims = claims;
        }

        public override Claim this[int position] => _claims[position];

        public override int Count => _claims.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.MemberClaimListItem, null);
            var claim = this[position];

            UpdateUI(view, claim);

            return view;
        }

        static void UpdateUI(View view, Claim claim)
        {
            var dentistLabel = view.FindViewById<TextView>(Resource.Id.DentistName);
            dentistLabel.Text = $"{claim.Provider.Name.First} {claim.Provider.Name.Last}";

            var serviceLabel = view.FindViewById<TextView>(Resource.Id.ServiceValue);
            serviceLabel.Text = claim.Service.Item1.ToShortDateString();

            var youPaidLabel = view.FindViewById<TextView>(Resource.Id.YouPaidValue);
            youPaidLabel.Text = "not_implemented";
        }
    }
}