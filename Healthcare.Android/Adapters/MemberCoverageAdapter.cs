using Android.App;
using Android.Widget;
using System.Collections.Generic;
using static Account;
using Android.Views;
using static Benefits;

namespace Healthcare.Android.Adapters
{
    class MemberCoverageAdapter : BaseAdapter<MemberPlan>
    {
        readonly Activity _context;
        readonly List<MemberPlan> _members;

        public MemberCoverageAdapter(Activity context, List<MemberPlan> members)
        {
            _context = context;
            _members = members;
        }

        public override MemberPlan this[int position] => _members[position];

        public override int Count => _members.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.MemberCoverageItem, null);
            var memberCoverage = this[position];

            var nameLabel = view.FindViewById<TextView>(Resource.Id.NameValue);
            nameLabel.Text = $"{memberCoverage.Member.Name.First} {memberCoverage.Member.Name.Last}";

            var memberIdLabel = view.FindViewById<TextView>(Resource.Id.MemberIdValue);
            memberIdLabel.Text = memberCoverage.Member.MemberId.Item;

            var dateOfBirthLabel = view.FindViewById<TextView>(Resource.Id.DOBValue);
            dateOfBirthLabel.Text = memberCoverage.Member.DateOfBirth.Item;

            return view;
        }
    }
}