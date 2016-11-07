module SignIn

open Account
open ValidationTrack
open InteractionLogic
open Confirmation

(* Types *)
type Credentials = { PatientId:PatientId; Password:Password }

type SignInResponse =
    | SignInNA
    | PatientIdRequired
    | PasswordRequired
    | SignedIn

type SignOutResponse =
    | FailedToSignOut
    | SignedOut

(* Functions *)
let credentials patientId password = { 
    PatientId= PatientId patientId
    Password = Password  password 
}

let signout memberSession = SignedOut

let trySignIn (credentials:Credentials) =

    let validateUserName credentials = 
        match credentials.PatientId with
        | PatientId v -> v |> failOnEmpty credentials PatientIdRequired

    let validatePassword credentials =
        match credentials.Password with
        | Password p -> p |> failOnEmpty credentials PasswordRequired
                        
    let validate = validateUserName >> bind validatePassword
    
    validate credentials

let onFormUpdated form (dispatcher:Dispatcher) (confirmation:IConfirmation) =
    match form with
    | Success form   -> dispatcher.ViewPortalDashboard()
    | Failure reason -> confirmation.Display()