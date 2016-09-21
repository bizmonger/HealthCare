﻿namespace ManageClaims

open System.Windows.Input
open Repositories
open InteractionLogic
open Claims

type ClaimsSummaryViewModel(memberId , dispatcher:Dispatcher , repository:IClaimsRepository) = 

    member val FamilySummary =      None   with get,set
    member val DependentSummaries = seq [] with get,set

    member this.LoadFamilySummary() =
        this.FamilySummary      <- repository.GetFamilySummary memberId

    member this.LoadMemberSummaries() =
        this.DependentSummaries <- repository.GetDependentSummaries memberId

    member this.OnSummarySelected summary =
        dispatcher.ViewMemberClaims summary.Member.MemberId