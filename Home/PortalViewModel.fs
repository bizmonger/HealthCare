namespace Home

open System.Windows.Input
open InteractionLogic
open Repositories
open Account

type PortalViewModel(memberId:MemberId , dispatcher:Dispatcher , repository:IBenefitsRepository) =

    member val LastAppointment = None with get,set

    member this.LoadLastAppointment =
        DelegateCommand( (fun _ -> this.LastAppointment <- repository.GetLastAppointment memberId) , 
                          fun _ -> true ) :> ICommand

    member this.ViewIdCard =
        DelegateCommand( (fun _ -> dispatcher.TryViewIdCard memberId) , 
                          fun _ -> true ) :> ICommand

    member this.ViewBenefits =
        DelegateCommand( (fun _ -> dispatcher.ViewCoverage memberId) , 
                          fun _ -> true ) :> ICommand

    member this.ViewProviders =
        DelegateCommand( (fun _ -> dispatcher.ViewProviders()) , 
                          fun _ -> true ) :> ICommand

    member this.ViewClaims =
        DelegateCommand( (fun _ -> dispatcher.ViewClaims memberId) , 
                          fun _ -> true ) :> ICommand