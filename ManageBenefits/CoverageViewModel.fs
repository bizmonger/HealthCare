namespace ManageBenefits

open System.Windows.Input
open InteractionLogic
open Benefits
open Repositories
open Account

type CoverageViewModel(memberId , repository:IBenefitsRepository) =

    member val MemberCoverages = seq [] with get,set

    member this.LoadCoverage() =
        this.MemberCoverages <- repository.GetMemberCoverages memberId