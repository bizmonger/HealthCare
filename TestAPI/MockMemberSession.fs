namespace TestAPI

open ManageAccount
open SignIn

type MockOnlineSession() =

    interface IMemberSession with
        
        member this.SignIn  PatientId = SignedIn
        member this.SignOut PatientId = SignedOut
