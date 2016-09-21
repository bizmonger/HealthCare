﻿namespace TestAPI

open Claims
open Account
open MockClaim
open Repositories

type MockClaimsRepository() =

    interface IClaimsRepository with
        
        member this.GetFamilySummary      memberId = Some SomeFamilySummary
        member this.GetSummary            memberId = Some SomeClaimsSummary
        member this.GetDependentSummaries memberId = SomeDependentSummaries
        member this.GetDetails            claimId =  Some anonymousClaim
        member this.GetPaymentSummary     claimId =  Some mockPaymentSummary
        member this.GetPaymentDetails     claimId =  Some anonymousPaymentDetails
        member this.GetServiceDetails     claimId =  Some anonymousServiceDetails
        member this.GetLastService        memberId = Some anonymousServiceDetails