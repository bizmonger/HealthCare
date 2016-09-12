namespace ManageBenefits

open System.Windows.Input
open InteractionLogic
open Account

type BenefitsPlanViewModel(dispatcher:Dispatcher , account:IdCard) =

    member this.ViewInNetwork =
        DelegateCommand ( (fun _ -> dispatcher.ViewInNetwork(account.MemberId)) , fun _ -> true ) :> ICommand

    member this.ViewOutOfNetwork =
        DelegateCommand ( (fun _ -> dispatcher.ViewOutOfNetwork(account.MemberId)) , fun _ -> true ) :> ICommand

    member this.ViewPreventiveAndDiagnostic =
        DelegateCommand ( (fun _ -> dispatcher.ViewPreventiveAndDiagnostic(account.MemberId)) , fun _ -> true ) :> ICommand

    member this.ViewRestoration =
        DelegateCommand ( (fun _ -> dispatcher.ViewRestoration(account.MemberId)) , fun _ -> true ) :> ICommand

    member this.ViewOralSurgery =
        DelegateCommand ( (fun _ -> dispatcher.ViewOralSurgery(account.MemberId)) , fun _ -> true ) :> ICommand

    member this.ViewPeriodontics =
        DelegateCommand ( (fun _ -> dispatcher.ViewPeriodontics(account.MemberId)) , fun _ -> true ) :> ICommand
