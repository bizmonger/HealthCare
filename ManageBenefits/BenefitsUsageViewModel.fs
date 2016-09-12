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

    member this.LoadInNetworkUsage =
        DelegateCommand( (fun _ -> this.InNetworkUsage <- repository.GetUsage memberId) , 
                          fun _ -> true ) :> ICommand

    member this.LoadOutOfNetworkUsage =
        DelegateCommand( (fun _ -> this.OutOfNetworkNetworkUsage <- repository.GetUsage memberId) , 
                          fun _ -> true ) :> ICommand

    member this.LoadMembers =
        DelegateCommand( (fun _ -> this.Members <- repository.GetMembers memberId) , 
                          fun _ -> true ) :> ICommand