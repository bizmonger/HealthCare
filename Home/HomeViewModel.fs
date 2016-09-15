namespace Home

open System.Windows.Input
open InteractionLogic
open Settings

type HomeViewModel (dispatcher:Dispatcher) as this =
    
    let mutable signedIn = false

    do dispatcher.SignInSuccessful.Add(fun _ -> signedIn <- true)
    do dispatcher.SettingsChanged.Add(fun s -> this.Settings <- s)

    member val Settings = { ViewIdCardFromHome=false } with get,set

    member this.SignIn =
        DelegateCommand( (fun _ -> dispatcher.ViewSignIn()), fun _ -> true ) :> ICommand

    member this.Register =
        DelegateCommand( (fun _ -> dispatcher.ViewRegistration()), fun _ -> true ) :> ICommand

    member this.ViewTips =
        DelegateCommand( (fun _ -> dispatcher.ViewTips()), fun _ -> true ) :> ICommand

    member this.ViewContact =
        DelegateCommand( (fun _ -> dispatcher.ViewContact()), fun _ -> true ) :> ICommand

    member this.ViewFAQ =
        DelegateCommand( (fun _ -> dispatcher.ViewFAQ()), fun _ -> true ) :> ICommand

    member this.ViewPrivacy =
        DelegateCommand( (fun _ -> dispatcher.ViewPrivacy()), fun _ -> true ) :> ICommand

    member this.ViewInfo =
        DelegateCommand( (fun _ -> dispatcher.ViewInfo()), fun _ -> true ) :> ICommand

    member this.FindProviders =
        DelegateCommand( (fun _ -> dispatcher.FindProviders()), fun _ -> true ) :> ICommand

    member this.TryViewIdCard =    (* Requires security *)
        DelegateCommand( (fun _ -> if signedIn || this.Settings.ViewIdCardFromHome 
                                   then dispatcher.TryViewIdCard()
                                   else ()), 
                          fun _ -> true ) :> ICommand