namespace ManageAccount

open System.Windows.Input
open InteractionLogic
open Account

type AccountViewModel(memberId:MemberId , dispatcher:Dispatcher) =

    member val AccountNumber = AccountNumber "need value" with get,set
    
    member this.ViewProfile =
        DelegateCommand( (fun _ -> dispatcher.ViewProfile memberId ) , fun _ -> true ) :> ICommand

    member this.ViewDependentProfiles =
        DelegateCommand( (fun _ -> dispatcher.ViewDependentProfiles memberId ) , fun _ -> true ) :> ICommand

    member this.ViewLoginSettings =
        DelegateCommand( (fun _ -> dispatcher.ViewLoginSettings memberId ) , fun _ -> true ) :> ICommand