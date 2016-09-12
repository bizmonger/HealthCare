namespace ManageClaims

open System.Windows.Input
open Repositories
open InteractionLogic

type ClaimsSummaryViewModel(memberId , repository:IClaimsRepository) = 

    member val FamilySummary =      repository.GetFamilySummary   memberId with get,set
    member val DependentSummaries = repository.GetDependentSummaries memberId with get,set

    member this.LoadFamilySummary =
        DelegateCommand( (fun _ -> this.FamilySummary <- repository.GetFamilySummary memberId) , fun _ -> true ) :> ICommand

    member this.LoadMemberSummaries =
        DelegateCommand( (fun _ -> this.DependentSummaries <- repository.GetDependentSummaries memberId) , fun _ -> true ) :> ICommand