namespace ManageClaims

open System.Windows.Input
open Repositories
open InteractionLogic
open Claims

type ClaimsSummaryViewModel(memberId , dispatcher:Dispatcher , repository:IClaimsRepository) = 

    member val FamilySummary =                repository.GetFamilySummary      memberId with get,set
    member val DependentSummaries =           repository.GetDependentSummaries memberId with get,set
    member val Summary:ClaimsSummary option = None with get,set

    member this.LoadFamilySummary() =
        this.FamilySummary      <- repository.GetFamilySummary memberId

    member this.LoadMemberSummaries() =
        this.DependentSummaries <- repository.GetDependentSummaries memberId

    member this.MemberClaimsSummary =
        DelegateCommand ( (fun _ -> match this.Summary with
                                    | Some s -> dispatcher.ViewClaims s.Member.MemberId
                                    | None   -> ()) , fun _ -> true) :> ICommand