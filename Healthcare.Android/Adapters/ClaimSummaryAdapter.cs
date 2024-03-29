using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using static Account;
using static Claims;

namespace Healthcare.Android.Adapters
{
    class ClaimSummaryAdapter : BaseAdapter<ClaimsSummary>
    {
        readonly Activity _context;
        readonly List<ClaimsSummary> _members;

        public ClaimSummaryAdapter(Activity context, List<ClaimsSummary> members)
        {
            _context = context;
            _members = members;
        }

        public override ClaimsSummary this[int position] => _members[position];

        public override int Count => _members.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.MemberCoverageItem, null);

            var claimsSummary = this[position];
            var member = claimsSummary.Member;

            UpdateUI(view, member);

            return view;
        }

        static void UpdateUI(View view, IdCard member)
        {
            var nameLabel = view.FindViewById<TextView>(Resource.Id.NameValue);
            nameLabel.Text = $"{member.Name.First} {member.Name.Last}";

            var PatientIdLabel = view.FindViewById<TextView>(Resource.Id.PatientIdValue);
            PatientIdLabel.Text = member.PatientId.Item;

            var dateOfBirthLabel = view.FindViewById<TextView>(Resource.Id.DOBValue);
            dateOfBirthLabel.Text = member.DateOfBirth.Item;
        }
    }
}