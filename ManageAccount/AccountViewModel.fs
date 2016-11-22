namespace ManageAccount

open System.Windows.Input
open InteractionLogic
open Account

type AccountViewModel(patientId:PatientId , dispatcher:Dispatcher) =

    member val AccountNumber = AccountNumber "need value" with get,set
    
    member this.ViewProfile =
        DelegateCommand( (fun _ -> dispatcher.ViewProfile patientId ) , fun _ -> true ) :> ICommand

    member this.ViewDependentProfiles =
        DelegateCommand( (fun _ -> dispatcher.ViewDependentProfiles patientId ) , fun _ -> true ) :> ICommand

    member this.ViewLoginSettings =
        DelegateCommand( (fun _ -> dispatcher.ViewLoginSettings patientId ) , fun _ -> true ) :> ICommand

    member this.ViewFiles =
        DelegateCommand ( (fun _ -> dispatcher.ViewFiles patientId) , 
                           fun _ -> true ) :> ICommand