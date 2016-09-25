namespace ManageBenefits

open System.Windows.Input
open InteractionLogic
open Benefits
open Repositories

type BenefitsUsageViewModel(memberId , repository:IBenefitsRepository) =
    
    let deductable = { Total= 0m; Spent=0m }
    let outOfPocket = OutOfPocket 0m

    member val InNetworkUsage =           { Deductable= deductable; OutOfPocket=outOfPocket } with get,set
    member val OutOfNetworkNetworkUsage = { Deductable= deductable; OutOfPocket=outOfPocket } with get,set
    member val Members = seq [] with get,set

    member this.Load() =
        this.InNetworkUsage           <- repository.GetUsage memberId
        this.OutOfNetworkNetworkUsage <- repository.GetUsage memberId
        this.Members                  <- repository.GetMemberCoverages memberId