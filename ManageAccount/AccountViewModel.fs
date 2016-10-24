namespace ManageAccount

open System.Windows.Input
open InteractionLogic
open Account

type AccountViewModel(PatientId:PatientId , dispatcher:Dispatcher) =

    member val AccountNumber = AccountNumber "need value" with get,set
    
    member this.ViewProfile =
        DelegateCommand( (fun _ -> dispatcher.ViewProfile PatientId ) , fun _ -> true ) :> ICommand

    member this.ViewDependentProfiles =
        DelegateCommand( (fun _ -> dispatcher.ViewDependentProfiles PatientId ) , fun _ -> true ) :> ICommand

    member this.ViewLoginSettings =
        DelegateCommand( (fun _ -> dispatcher.ViewLoginSettings PatientId ) , fun _ -> true ) :> ICommand