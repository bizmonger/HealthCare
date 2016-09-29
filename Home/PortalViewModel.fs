namespace Home

open System.Windows.Input
open InteractionLogic
open Repositories
open Account

type PortalViewModel(memberId:MemberId , dispatcher:Dispatcher , repository:IBenefitsRepository) =

    member val LastAppointment = None with get,set

    member this.Load() =
        this.LastAppointment <- repository.GetLastAppointment memberId

    member this.ViewIdCard =
        DelegateCommand( (fun _ -> dispatcher.TryViewIdCard memberId) , 
                          fun _ -> true ) :> ICommand

    member this.ViewBenefits =
        DelegateCommand( (fun _ -> dispatcher.ViewCoverage memberId) , 
                          fun _ -> true ) :> ICommand

    member this.ViewProviders =
        DelegateCommand( (fun _ -> dispatcher.FindProviders()) , 
                          fun _ -> true ) :> ICommand

    member this.ViewFamilyClaims =
        DelegateCommand( (fun _ -> dispatcher.ViewFamilyClaims memberId) , 
                          fun _ -> true ) :> ICommand

    member this.ViewContactInfo =
        DelegateCommand( (fun _ -> dispatcher.ViewContact()) , 
                          fun _ -> true ) :> ICommand