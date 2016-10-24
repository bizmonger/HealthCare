namespace ManageBenefits

open System.Windows.Input
open InteractionLogic
open Benefits
open Repositories
open Account

type CoverageViewModel(PatientId , repository:IBenefitsRepository) =

    member val MemberCoverages = seq [] with get,set

    member this.Load() =
        this.MemberCoverages <- repository.GetMemberCoverages PatientId
