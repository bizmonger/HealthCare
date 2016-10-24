namespace ManageAccount

open Account
open SignIn

type IMemberSession =

    abstract member SignIn  : PatientId -> SignInResponse
    abstract member SignOut : PatientId -> SignOutResponse