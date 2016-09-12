module SignIn

open ValidationTrack
open InteractionLogic
open Confirmation

(* Types *)
type User =        User     of string
type Password =    Password of string
type Credentials = { User:User; Password:Password }

type SignInResponse =
    | SignInNA
    | UserNameRequired
    | PasswordRequired

(* Functions *)
let credentials user password = { 
    User=      User     user
    Password = Password password }

let trySignIn (credentials:Credentials) =

    let validateUserName credentials = 
        match credentials.User with
        | User v ->     v |> failOnEmpty credentials UserNameRequired

    let validatePassword credentials =
        match credentials.Password with
        | Password p -> p |> failOnEmpty credentials PasswordRequired
                        
    let validate =
        let validatePassword' = bind validatePassword
        validateUserName >> validatePassword'
    
    validate credentials

let onFormUpdated form (dispatcher:Dispatcher) (confirmation:IConfirmation) =
    match form with
    | Success form   -> dispatcher.SignedIn()
    | Failure reason -> confirmation.Display()