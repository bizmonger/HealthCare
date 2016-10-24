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
                PatientId = SomeEmail.Item, // FindViewById<EditText>(Resource.Id.PatientId).Text,
                Password = SomePassword     // FindViewById<EditText>(Resource.Id.password).Text,
            };

            _viewModel.Register.Execute(null);
        }
    }
}