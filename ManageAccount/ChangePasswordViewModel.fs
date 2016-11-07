﻿namespace ManageAccount

open Account
open InteractionLogic
open System.Windows.Input
open Repositories

type ChangePasswordViewModel(repository:IProfileRepository) =
    
    member val Password        = "" with get,set
    member val ConfirmPassword = "" with get,set

    member this.Save =

        let change = { Old= Password this.Password
                       New= Password this.ConfirmPassword }

        DelegateCommand( (fun _ -> repository.TryChangePassword change) ,
                          fun _ -> change.Old = change.New) :> ICommand