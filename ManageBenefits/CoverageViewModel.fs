namespace ManageBenefits

open System.Windows.Input
open InteractionLogic
open Benefits
open Repositories
open Account

type CoverageViewModel(patientId , repository:IBenefitsRepository) =

    member val MemberCoverages = seq [] with get,set

    member this.Load() =
        this.MemberCoverages <- repository.GetMemberCoverages patientId