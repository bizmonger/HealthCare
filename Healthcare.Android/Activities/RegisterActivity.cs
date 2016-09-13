using Android.App;
using Android.OS;
using Android.Widget;
using InteractionLogic;
using ManageAccount;

namespace Healthcare.Android
{
    [Activity(Label = nameof(RegisterActivity))]
    class RegisterActivity : Activity
    {
        readonly Dispatcher _dispatcher = Global.Instance.Dispatcher;
        RegisterViewModel _viewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Register);

            _viewModel = new RegisterViewModel(_dispatcher);

            var next = FindViewById<Button>(Resource.Id.next);

            next.Click += (s, e) =>
                {
                    _viewModel.FirstName = FindViewById<EditText>(Resource.Id.firstName).Text;
                    _viewModel.LastName = FindViewById<EditText>(Resource.Id.lastName).Text;
                    _viewModel.Email = FindViewById<EditText>(Resource.Id.memberId).Text;
                    _viewModel.DateOfBirth = FindViewById<EditText>(Resource.Id.dateOfBirth).Text;
                    _viewModel.Zipcode = int.Parse(FindViewById<EditText>(Resource.Id.zipCode).Text);

                    _viewModel.Register.Execute(null);
                };
        }
    }
}