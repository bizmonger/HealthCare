namespace Home

open System.Windows.Input
open InteractionLogic
open Account
open Contact
open Repositories
open Claims
open System

type ContactViewModel(memberId , companyId , dispatcher:Dispatcher , companyRepository:ICompanyRepository, claimsRepository:IClaimsRepository) =

    let isPastDue (date:DateTime) months =
        let span = DateTime.Now.Subtract date
        span.TotalDays > (months * 30.0)

    member val LastService = None        with get,set
    member val IsPastDue   = false       with get,set
    member val Phone       = "not found" with get,set
    member val Email       = "not found" with get,set

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
        this.IsPastDue   <-  match this.LastService with
                             | Some v -> match v.Date with ServiceDate date -> isPastDue date 6.0
                             | None   -> false