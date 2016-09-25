namespace ManageClaims

open System.Windows.Input
open InteractionLogic
open Repositories
open Claims

type ClaimsDetailViewModel(claimId:ClaimId , dispatcher:Dispatcher , repository:IClaimsRepository) =

    member val Claim = None with get,set
    member val PaymentSummary = None with get,set

    member this.Load() =
        this.Claim          <- repository.GetDetails claimId
        this.PaymentSummary <- repository.GetPaymentSummary claimId

    member this.ViewServiceDetails =
        DelegateCommand( (fun _ -> dispatcher.ViewServiceDetails claimId) , 
                          fun _ -> true ) :> ICommand

    member this.ViewPaymentDetails =
        DelegateCommand( (fun _ -> dispatcher.ViewPaymentDetails claimId) , 
                          fun _ -> true ) :> ICommand