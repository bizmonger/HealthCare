namespace ManageClaims

open System.Windows.Input
open InteractionLogic
open Account
open Repositories
open Claims

type ServiceDetailsViewModel(claimId:ClaimId , repository:IClaimsRepository) =

    member val ServiceDetails = None with get,set

    member this.LoadServiceDetails =
        DelegateCommand ( (fun _ -> this.ServiceDetails <- repository.GetServiceDetails claimId) , fun _ -> true ) :> ICommand