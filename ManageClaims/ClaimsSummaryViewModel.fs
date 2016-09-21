namespace ManageClaims

open System.Windows.Input
open Repositories
open InteractionLogic

type ClaimsSummaryViewModel(memberId , repository:IClaimsRepository) = 

    member val FamilySummary =      repository.GetFamilySummary   memberId with get,set
    member val DependentSummaries = repository.GetDependentSummaries memberId with get,set

    member this.LoadFamilySummary() =
        this.FamilySummary <- repository.GetFamilySummary memberId

    member this.LoadMemberSummaries() =
        this.DependentSummaries <- repository.GetDependentSummaries memberId