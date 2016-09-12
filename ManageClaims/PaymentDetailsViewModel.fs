namespace ManageClaims

open System.Windows.Input
open InteractionLogic
open Account
open Repositories
open Claims

type PaymentDetailsViewModel(claimId:ClaimId , repository:IClaimsRepository) =

    member val PaymentDetails = None with get,set

    member this.LoadPaymentDetails =
        DelegateCommand ( (fun _ -> this.PaymentDetails <- repository.GetPaymentDetails claimId) , fun _ -> true ) :> ICommand