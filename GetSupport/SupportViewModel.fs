namespace GetSupport

open System.Windows.Input
open InteractionLogic
open Account
open Repositories

type SupportViewModel(memberId:MemberId , dispatcher:Dispatcher , repository:IClaimsRepository) =
    
    let mutable phone = Phone ""
    let mutable email = Email ""
    let mutable lastService = None

    member this.LastService 
        with get() = lastService
        and private set(value) = lastService <- value

    member this.Phone 
        with get() = phone
        and private set(value) = phone <- value

    member this.Email
        with get() = email
        and private set(value) = email <- value

    member this.CallSupport =
        DelegateCommand( (fun _ -> dispatcher.CallSupport()) , 
                          fun _ -> true ) :> ICommand

    member this.EmailSupport =
        DelegateCommand( (fun _ -> dispatcher.EmailSupport()) , 
                          fun _ -> true ) :> ICommand

    member this.LoadLastService =
        DelegateCommand( (fun _ -> this.LastService <- repository.GetLastService memberId) , 
                          fun _ -> true ) :> ICommand