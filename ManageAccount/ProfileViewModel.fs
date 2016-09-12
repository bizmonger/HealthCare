namespace ManageAccount

open System.Windows.Input
open InteractionLogic
open Account
open Repositories

type ProfileViewModel(memberId:MemberId , dispatcher:Dispatcher , repository:IProfileRepository) =

    member val Profile:Profile option = None with get,set
    member val Dependents:Profile list = [] with get,set

    member this.LoadProfile =
        DelegateCommand( (fun _ -> this.Profile <- repository.GetProfile memberId) , 
                          fun _ -> true ) :> ICommand

    member this.LoadDependents =
        DelegateCommand( (fun _ -> this.Dependents <- repository.GetDependents memberId) , 
                          fun _ -> true ) :> ICommand

    member this.ViewProfile =
        DelegateCommand( (fun _ -> dispatcher.ViewProfile memberId) , 
                          fun _ -> true ) :> ICommand