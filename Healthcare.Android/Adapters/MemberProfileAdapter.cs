using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using static Account;
using static Claims;

namespace Healthcare.Android.Adapters
{
    class MemberProfileAdapter : BaseAdapter<Profile>
    {
        readonly Activity _context;
        readonly List<Profile> _profiles;

        public MemberProfileAdapter(Activity context, List<Profile> idCards)
        {
            _context = context;
            _profiles = idCards;
        }

        public override Profile this[int position] => _profiles[position];

        public override int Count => _profiles.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.MemberProfileListItem, null);
            var profile = this[position];

            UpdateUI(view, profile);

            return view;
        }

        static void UpdateUI(View view, Profile profile)
        {
            var nameLabel = view.FindViewById<TextView>(Resource.Id.NameValue);
            nameLabel.Text = $"{profile.IdCard.Name.First} {profile.IdCard.Name.Last}";

            var memberLabel = view.FindViewById<TextView>(Resource.Id.MemberIdValue);
            memberLabel.Text = profile.IdCard.MemberId.Item;

            var dobLabel = view.FindViewById<TextView>(Resource.Id.DOBValue);
            dobLabel.Text = profile.IdCard.DateOfBirth.Item;
        }
    }
}