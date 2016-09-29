namespace ManageBenefits

open System.Windows.Input
open InteractionLogic
open Account

type BenefitsPlanViewModel(memberId , dispatcher:Dispatcher) =

    member this.ViewInNetwork =
        DelegateCommand ( (fun _ -> dispatcher.ViewInNetwork memberId) , fun _ -> true ) :> ICommand

    member this.ViewOutOfNetwork =
        DelegateCommand ( (fun _ -> dispatcher.ViewOutOfNetwork memberId) , fun _ -> true ) :> ICommand

    member this.ViewPreventiveAndDiagnostic =
        DelegateCommand ( (fun _ -> dispatcher.ViewPreventiveAndDiagnostic memberId) , fun _ -> true ) :> ICommand

    member this.ViewRestoration =
        DelegateCommand ( (fun _ -> dispatcher.ViewRestoration memberId) , fun _ -> true ) :> ICommand

    member this.ViewOralSurgery =
        DelegateCommand ( (fun _ -> dispatcher.ViewOralSurgery memberId) , fun _ -> true ) :> ICommand

    member this.ViewPeriodontics =
        DelegateCommand ( (fun _ -> dispatcher.ViewPeriodontics memberId) , fun _ -> true ) :> ICommand
