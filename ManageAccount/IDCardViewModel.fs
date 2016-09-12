namespace ManageAccount

open System.Windows.Input
open InteractionLogic

open Account
open Settings
open Repositories

type IdCardViewModel (idCard:IdCard , dispatcher:Dispatcher) =

    let settings = FeatureSettings()

    member val IDCard =   idCard   with get,set
    member val Settings = settings with get,set

    member this.Print =
        DelegateCommand( (fun _ -> dispatcher.PrintId this.IDCard), (fun _ -> true) ) :> ICommand

    member this.Email =
        DelegateCommand( (fun _ -> dispatcher.EmailId this.IDCard), (fun _ -> true) ) :> ICommand

    member this.EnableHomeAccess =
        let features = { ViewIdCardFromHome=true }
        DelegateCommand( (fun _ -> settings.Save features
                                   dispatcher.ChangeSettings features), (fun _ -> true) ) :> ICommand