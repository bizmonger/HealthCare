namespace ManageBenefits

open System.Windows.Input
open InteractionLogic
open Benefits
open Repositories

type BenefitsUsageViewModel(PatientId , repository:IBenefitsRepository) =

    member val InNetworkUsage =           None with get,set
    member val OutOfNetworkNetworkUsage = None with get,set
    member val Members =                  seq [] with get,set

    member this.Load() =
        this.InNetworkUsage           <- repository.GetUsage PatientId
        this.OutOfNetworkNetworkUsage <- repository.GetUsage PatientId
        this.Members                  <- repository.GetMemberCoverages PatientId
