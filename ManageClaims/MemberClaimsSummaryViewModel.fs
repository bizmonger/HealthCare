namespace ManageClaims

open System.Windows.Input
open Repositories
open InteractionLogic
open Claims

type MemberClaimsSummaryViewModel(memberId , dispatcher:Dispatcher , repository:IClaimsRepository) = 

    member val Summary:ClaimsSummary option = None with get,set
    member val Claims =  seq [] with get,set

    member this.Load() =
        this.Summary <- repository.GetSummary memberId
        this.Claims  <- match this.Summary with
                        | Some v -> v.Claims
                        | None   -> seq []

    member this.OnClaimSelected (claim:Claim) =
        dispatcher.ViewClaim claim.ClaimId