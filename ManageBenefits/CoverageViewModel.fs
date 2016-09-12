namespace ManageBenefits

open System.Windows.Input
open InteractionLogic
open Benefits
open Repositories
open Account

type CoverageViewModel(memberId , repository:IBenefitsRepository) =

    member val Coverage = None with get,set

    member this.LoadCoverage =
        DelegateCommand ( (fun _ -> this.Coverage <- repository.GetCoverage memberId) , 
                           fun _ -> true ) :> ICommand
