using Android.App;
using Android.OS;
using Android.Views;

namespace Healthcare.Android.Fragments
{
    public class WelcomeFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) =>
            inflater.Inflate(Resource.Layout.WelcomeFragment, container, false);
    }
}