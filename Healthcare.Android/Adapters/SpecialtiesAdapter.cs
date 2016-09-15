using System;
using Android.Views;
using Android.Widget;
using static Claims;
using System.Collections.Generic;
using Android.App;

namespace Healthcare.Android.Adapters
{
    class SpecialtiesAdapter : BaseAdapter<string>
    {
        readonly Activity _context;
        readonly List<string> _specialties;

        public SpecialtiesAdapter(Activity context, List<string> specialties)
        {
            _context = context;
            _specialties = specialties;
        }

        public override string this[int position] => _specialties[position];

        public override int Count => _specialties.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent) =>
            convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.SpecialtiesListItem, null);
    }
}