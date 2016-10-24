namespace ManageBenefits

open System.Windows.Input
open InteractionLogic
open Account
open Repositories
open Benefits

type BenefitsPlanViewModel(PatientId , dispatcher:Dispatcher, repository:IBenefitsRepository) =

    member val Summary:Summary option = None with get,set

    member this.ViewInNetwork =
        DelegateCommand ( (fun _ -> dispatcher.ViewInNetwork PatientId) , fun _ -> true ) :> ICommand

    member this.ViewOutOfNetwork =
        DelegateCommand ( (fun _ -> dispatcher.ViewOutOfNetwork PatientId) , fun _ -> true ) :> ICommand

    member this.ViewPreventiveAndDiagnostic =
        DelegateCommand ( (fun _ -> dispatcher.ViewPreventiveAndDiagnostic PatientId) , fun _ -> true ) :> ICommand

    member this.ViewRestoration =
        DelegateCommand ( (fun _ -> dispatcher.ViewRestoration PatientId) , fun _ -> true ) :> ICommand

    member this.ViewOralSurgery =
        DelegateCommand ( (fun _ -> dispatcher.ViewOralSurgery PatientId) , fun _ -> true ) :> ICommand

    member this.ViewPeriodontics =
        DelegateCommand ( (fun _ -> dispatcher.ViewPeriodontics PatientId) , fun _ -> true ) :> ICommand

    member this.Load() =
        match repository.GetCoverage PatientId with
        | Some v -> this.Summary <- Some v.Summary
        | None   -> this.Summary <- None
        
