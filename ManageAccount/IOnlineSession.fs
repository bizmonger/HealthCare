namespace ManageAccount

open Account
open SignIn

type IMemberSession =

    abstract member SignIn  : MemberId -> SignInResponse
    abstract member SignOut : MemberId -> SignOutResponse