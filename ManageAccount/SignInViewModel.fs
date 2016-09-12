namespace ManageAccount

open System.Windows.Input
open ValidationTrack
open InteractionLogic

open SignIn
open Confirmation
open InteractionLogic

type SignInViewModel(dispatcher:Dispatcher) =

    member val UserName = "" with get,set
    member val Password = "" with get,set

    member val Form = Failure SignInNA with get,set
    member val TryAgainConfirmation = TryAgainConfirmation() :> IConfirmation with get,set

    member this.SignIn =

        let credentials = credentials this.UserName this.Password

        DelegateCommand( (fun _ -> this.Form <- trySignIn credentials
                                   onFormUpdated this.Form dispatcher this.TryAgainConfirmation), 
                          fun _ -> true ) :> ICommand