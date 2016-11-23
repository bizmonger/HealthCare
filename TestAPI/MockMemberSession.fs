namespace TestAPI

open ManageAccount
open SignIn

type MockOnlineSession() =

    interface IMemberSession with
        
        member this.SignIn  patientId = SignedIn
        member this.SignOut patientId = SignedOut
