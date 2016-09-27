namespace ManageClaims

open System.Windows.Input
open Repositories
open InteractionLogic
open Claims

type ClaimsSummaryViewModel(memberId , dispatcher:Dispatcher , repository:IClaimsRepository) = 

    member val FamilySummary =      None   with get,set
    member val DependentSummaries = seq [] with get,set
    member val DependentSummary =   None   with get,set

    member this.Load() =
        this.FamilySummary      <- repository.GetFamilySummary      memberId
        this.DependentSummaries <- repository.GetDependentSummaries memberId

    member this.SetDependentSummary summary =
        this.DependentSummary <- Some summary

    member this.ViewClaims =

        DelegateCommand( (fun _ -> match this.DependentSummary with
                                   | Some v -> dispatcher.ViewMemberClaims v.Member.MemberId
                                   | None   -> ()), 
                          fun _ -> true ) :> ICommand