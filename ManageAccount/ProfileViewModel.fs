﻿namespace ManageAccount

open System.Windows.Input
open InteractionLogic
open Account
open Repositories

type ProfileViewModel(memberId:MemberId , dispatcher:Dispatcher , repository:IProfileRepository) =

    member val Profile:Profile option = None with get,set
    member val Dependents:Profile list = [] with get,set
    member val Dependent:Profile option = None with get,set

    member this.Load() =
        this.Profile    <- repository.GetProfile    memberId
        this.Dependents <- repository.GetDependents memberId

    member this.ViewDependent =

        DelegateCommand ( (fun _ -> match this.Dependent with
                                    | Some v -> dispatcher.ViewProfile v.IdCard.MemberId
                                    | None   -> ()) , 
                           fun _ -> this.Dependent.IsSome) :> ICommand