namespace ManageClaims

open System.Windows.Input
open InteractionLogic
open Account
open Repositories
open Claims

type PaymentDetailsViewModel(claimId:ClaimId , repository:IClaimsRepository) =

    member val PaymentDetails = None with get,set

    member this.Load() =
        this.PaymentDetails <- repository.GetPaymentDetails claimId