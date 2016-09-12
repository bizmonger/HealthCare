namespace ManageBenefits

open System.Windows.Input
open Account
open Benefits
open Repositories
open InteractionLogic

type BenefitsOverviewViewModel(repository:IBenefitsRepository , dispatcher:Dispatcher , account:IdCard) =

    let deductable = { Total=100m; Spent=50m } 

    let inNetwork = { 
        PreventiveAndDiagnostic= PreventiveAndDiagnostic 100
        Restoration=             Restoration  100
        OralSurgery=             OralSurgery  100
        Periodontics=            Periodontics 100 }

    let outOfNetwork = { 
        PreventiveAndDiagnostic= PreventiveAndDiagnostic 100
        Restoration=             Restoration  100
        OralSurgery=             OralSurgery  100
        Periodontics=            Periodontics 100 }

    let networks = { InNetwork= inNetwork ; OutOfNetwork=outOfNetwork }

    let summary:Summary = {
        Deductable=deductable
        OutOfPocket=OutOfPocket     100m
        AnnualMaximum=AnnualMaximum 100m
        Networks=networks }

    let usage =    { Deductable=deductable; OutOfPocket=OutOfPocket 100m }
    let coverage = { Member=account ; Summary=summary }
    let overview = { Coverage= coverage ; Usage=usage }

    member val Overview = overview with get,set

    member this.Load memberId = 
        this.Overview <- repository.GetOverview memberId

    member this.ViewPlan =
        DelegateCommand ( (fun _ -> dispatcher.ViewPlan(account.MemberId)) , fun _ -> true ) :> ICommand

    member this.ViewCoverage =
        DelegateCommand ( (fun _ -> dispatcher.ViewCoverage(account.MemberId)) , fun _ -> true ) :> ICommand

    member this.ViewUsage =
        DelegateCommand ( (fun _ -> dispatcher.ViewUsage(account.MemberId)) , fun _ -> true ) :> ICommand