namespace TestAPI

open Claims
open Account
open MockClaim
open Repositories

type MockClaimsRepository() =

    interface IClaimsRepository with
        
        member this.GetFamilySummary      patientId = Some SomeFamilySummary
        member this.GetSummary            patientId = Some SomeClaimsSummary
        member this.GetDependentSummaries patientId = SomeDependentSummaries
        member this.GetDetails            claimId =   Some SomeClaim
        member this.GetPaymentSummary     claimId =   Some SomePaymentSummary
        member this.GetPaymentDetails     claimId =   Some anonymousPaymentDetails
        member this.GetServiceDetails     claimId =   Some anonymousServiceDetails
        member this.GetLastService        patientId = Some anonymousServiceDetails
