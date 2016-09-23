namespace Home

open System.Windows.Input
open InteractionLogic

type MenuViewModel(memberId , dispatcher:Dispatcher) =
    
    member this.ViewAccount =
        DelegateCommand( (fun _ -> dispatcher.ViewAccount memberId ) , fun _ -> true ) :> ICommand