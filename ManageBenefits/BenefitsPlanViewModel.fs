﻿namespace ManageBenefits

open System.Windows.Input
open InteractionLogic
open Account
open Repositories
open Benefits

type BenefitsPlanViewModel(patientId , dispatcher:Dispatcher, repository:IBenefitsRepository) =

    member val Summary:Summary option = None with get,set

    member this.ViewInNetwork =
        DelegateCommand ( (fun _ -> dispatcher.ViewInNetwork patientId) , fun _ -> true ) :> ICommand

    member this.ViewOutOfNetwork =
        DelegateCommand ( (fun _ -> dispatcher.ViewOutOfNetwork patientId) , fun _ -> true ) :> ICommand

    member this.ViewPreventiveAndDiagnostic =
        DelegateCommand ( (fun _ -> dispatcher.ViewPreventiveAndDiagnostic patientId) , fun _ -> true ) :> ICommand

    member this.ViewRestoration =
        DelegateCommand ( (fun _ -> dispatcher.ViewRestoration patientId) , fun _ -> true ) :> ICommand

    member this.ViewOralSurgery =
        DelegateCommand ( (fun _ -> dispatcher.ViewOralSurgery patientId) , fun _ -> true ) :> ICommand

    member this.ViewPeriodontics =
        DelegateCommand ( (fun _ -> dispatcher.ViewPeriodontics patientId) , fun _ -> true ) :> ICommand

    member this.Load() =
        match repository.GetCoverage patientId with
        | Some v -> this.Summary <- Some v.Summary
        | None   -> this.Summary <- None
        
