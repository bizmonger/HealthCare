namespace ManageClaims

open InteractionLogic
open Account
open Repositories
open Claims

type ServiceDetailsViewModel(claimId:ClaimId , repository:IClaimsRepository) =

    member val ServiceDetails = None with get,set

    member this.Load() =
        this.ServiceDetails <- repository.GetServiceDetails claimId