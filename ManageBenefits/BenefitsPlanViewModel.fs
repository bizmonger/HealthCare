namespace ManageBenefits

open System.Windows.Input
open InteractionLogic
open Account
open Repositories
open Benefits

type BenefitsPlanViewModel(memberId , dispatcher:Dispatcher, repository:IBenefitsRepository) =

    member val Summary:Summary option = None with get,set

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

    member this.Load() =

        let coverage = repository.GetCoverage memberId

        match coverage with
        | Some v -> this.Summary <- Some v.Summary
        | None   -> this.Summary <- None
        
