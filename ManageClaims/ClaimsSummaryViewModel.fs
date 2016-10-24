namespace ManageClaims

open System.Windows.Input
open Repositories
open InteractionLogic
open Claims

type ClaimsSummaryViewModel(PatientId , dispatcher:Dispatcher , repository:IClaimsRepository) = 

    member val FamilySummary =      None   with get,set
    member val DependentSummaries = seq [] with get,set
    member val DependentSummary =   None   with get,set

    member this.Load() =
        this.FamilySummary      <- repository.GetFamilySummary      PatientId
        this.DependentSummaries <- repository.GetDependentSummaries PatientId

    member this.SetDependentSummary summary =
        this.DependentSummary <- Some summary

    member this.ViewClaims =

        DelegateCommand( (fun _ -> match this.DependentSummary with
                                   | Some v -> dispatcher.ViewMemberClaims v.Member.PatientId
                                   | None   -> ()), 
                          fun _ -> true ) :> ICommand