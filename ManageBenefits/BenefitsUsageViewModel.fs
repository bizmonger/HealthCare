namespace ManageBenefits

open System.Windows.Input
open InteractionLogic
open Benefits
open Repositories

type BenefitsUsageViewModel(memberId , repository:IBenefitsRepository) =

    member val InNetworkUsage =           None with get,set
    member val OutOfNetworkNetworkUsage = None with get,set
    member val Members =                  seq [] with get,set

    member this.Load() =
        this.InNetworkUsage           <- repository.GetUsage memberId
        this.OutOfNetworkNetworkUsage <- repository.GetUsage memberId
        this.Members                  <- repository.GetMemberCoverages memberId