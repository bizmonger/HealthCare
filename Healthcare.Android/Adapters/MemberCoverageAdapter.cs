using Android.App;
using Android.Widget;
using System.Collections.Generic;
using static Account;
using Android.Views;
using System;
using System.Linq;

namespace Healthcare.Android.Adapters
{
    class MemberListViewAdapter : BaseAdapter
    {
        readonly Activity _context;
        readonly List<IdCard> _members;

        public MemberListViewAdapter(Activity context, List<IdCard> members)
        {
            _context = context;
            _members = members;
        }

        public override int Count => _members.Count;

        public override Java.Lang.Object GetItem(int position) => null;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.MemberCoverageItem, null);
            return view;
        }
    }
}