namespace Home

open System.Windows.Input
open InteractionLogic

type MenuViewModel(PatientId , dispatcher:Dispatcher) =
    
    member this.ViewAccount =
        DelegateCommand( (fun _ -> dispatcher.ViewAccount PatientId ) , fun _ -> true ) :> ICommand
