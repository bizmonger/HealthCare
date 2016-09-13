using System;
using Android.Widget;
using ManageAccount;

namespace Healthcare.Android
{
    partial class RegisterActivity
    {
        void OnNext(object sender, EventArgs e)
        {
            _viewModel = new RegisterViewModel(_dispatcher)
            {
                FirstName = FindViewById<EditText>(Resource.Id.firstName).Text,
                LastName = FindViewById<EditText>(Resource.Id.lastName).Text,
                Email = FindViewById<EditText>(Resource.Id.memberId).Text,
                DateOfBirth = FindViewById<EditText>(Resource.Id.dateOfBirth).Text,
                Zipcode = int.Parse(FindViewById<EditText>(Resource.Id.zipCode).Text)
            };

            _viewModel.Register.Execute(null);
        }
    }
}