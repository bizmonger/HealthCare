namespace TestAPI

open ManageAccount
open SignIn

type MockOnlineSession() =

    interface IMemberSession with
        
        member this.SignIn  memberId = SignedIn
        member this.SignOut memberId = SignedOut