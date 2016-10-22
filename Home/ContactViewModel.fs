namespace Home

open System.Windows.Input
open InteractionLogic
open Account
open Contact
open Repositories

type ContactViewModel(memberId , companyId , dispatcher:Dispatcher , companyRepository:ICompanyRepository, claimsRepository:IClaimsRepository) =

    member val LastService = None with get,set
    member val Phone       = "" with get,set
    member val Email       = "" with get,set

    member this.CallSupport =
        DelegateCommand( (fun _ -> dispatcher.CallSupport()) , 
                          fun _ -> true ) :> ICommand

    member this.EmailSupport =
        DelegateCommand( (fun _ -> dispatcher.EmailSupport()) , 
                          fun _ -> true ) :> ICommand

    member this.Load() =
        let contact = companyRepository.GetContactInfo companyId

        match contact with
        | Some c -> 
            this.Phone <- match c.Phone with Phone v -> v
            this.Email <- match c.Email with Email v -> v
        | None   -> ()

        this.LastService <- claimsRepository.GetLastService memberId