using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using static Account;
using static Claims;

namespace Healthcare.Android.Adapters
{
    class MemberProfileAdapter : BaseAdapter<IdCard>
    {
        readonly Activity _context;
        readonly List<IdCard> _idCards;

        public MemberProfileAdapter(Activity context, List<IdCard> idCards)
        {
            _context = context;
            _idCards = idCards;
        }

        public override IdCard this[int position] => _idCards[position];

        public override int Count => _idCards.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.MemberProfileListItem, null);
            var claim = this[position];

            UpdateUI(view, claim);

            return view;
        }

        static void UpdateUI(View view, IdCard idCard)
        {
            var nameLabel = view.FindViewById<TextView>(Resource.Id.NameValue);
            nameLabel.Text = $"{idCard.Name.First} {idCard.Name.Last}";

            var memberLabel = view.FindViewById<TextView>(Resource.Id.MemberIdValue);
            memberLabel.Text = idCard.MemberId.Item;

            var dobLabel = view.FindViewById<TextView>(Resource.Id.DOBValue);
            dobLabel.Text = idCard.DateOfBirth.Item;
        }
    }
}