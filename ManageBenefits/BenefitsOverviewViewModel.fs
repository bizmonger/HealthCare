namespace ManageBenefits

open System.Windows.Input
open Account
open Benefits
open Repositories
open InteractionLogic

type BenefitsOverviewViewModel(patientId:PatientId , repository:IBenefitsRepository , dispatcher:Dispatcher) =

    let deductable = { Total=100m; Spent=50m } 

    let inNetwork = { 
        PreventiveAndDiagnostic= PreventiveAndDiagnostic 100
        Restoration=             Restoration  100
        OralSurgery=             OralSurgery  100
        Periodontics=            Periodontics 100 }

    let outOfNetwork = { 
        PreventiveAndDiagnostic= PreventiveAndDiagnostic 100
        Restoration=             Restoration  100
        OralSurgery=             OralSurgery  100
        Periodontics=            Periodontics 100 }

    member val Summary:Summary option = None with get,set

    member val Overview:BenefitsOverview option = None with get,set

    member this.Load() = 
        this.Overview <- repository.GetOverview patientId

        match repository.GetCoverage patientId with
        | Some v -> this.Summary <- Some v.Summary
        | None   -> this.Summary <- None

    member this.ViewPlan =
        DelegateCommand ( (fun _ -> match this.Overview with
                                    | Some v -> dispatcher.ViewPlan(v.Coverage.Member.PatientId)
                                    | None   -> ()) , 
                           fun _ -> true ) :> ICommand

    member this.ViewCoverage =
        DelegateCommand ( (fun _ -> match this.Overview with
                                    | Some v -> dispatcher.ViewCoverage(v.Coverage.Member.PatientId)
                                    | None   -> ()) ,  
                           fun _ -> true ) :> ICommand

    member this.ViewUsage =
        DelegateCommand ( (fun _ -> match this.Overview with
                                    | Some v -> dispatcher.ViewUsage(v.Coverage.Member.PatientId)
                                    | None   -> ()) ,  
                           fun _ -> true ) :> ICommand