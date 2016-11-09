namespace ManageAccount

open InteractionLogic
open System.Windows.Input
open Account

type LoginSettingsViewModel(patientId:PatientId , dispatcher:Dispatcher) =

    member this.ChangePassword =
        
        DelegateCommand( (fun _ -> dispatcher.ViewChangePassword patientId ) , 
                         fun _ -> true ) :> ICommand