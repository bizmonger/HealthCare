using ManageAccount;
using System;
using static MockMember;

namespace Healthcare.Android
{
    partial class RegisterActivity
    {
        void OnNext(object sender, EventArgs e)
        {
            _viewModel = new RegisterViewModel(Global.Dispatcher)
            {
                FirstName = SomeFirstName,    // FindViewById<EditText>(Resource.Id.firstName).Text,
                MiddleName = "",              // string.Empty,
                LastName = SomeLastName,      // FindViewById<EditText>(Resource.Id.lastName).Text,
                DateOfBirth = SomeDateOfBirth,// FindViewById<EditText>(Resource.Id.dateOfBirth).Text,
                Email = SomeEmail.Item,       // FindViewById<EditText>(Resource.Id.PatientId).Text,
                Password = SomePassword,      // FindViewById<EditText>(Resource.Id.password).Text,
                Zipcode = SomeZipCode.Item    // int.Parse(FindViewById<EditText>(Resource.Id.zipCode).Text),
            };

            _viewModel.Register.Execute(null);
        }
    }
}