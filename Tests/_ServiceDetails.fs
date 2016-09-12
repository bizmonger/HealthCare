module ServiceDetails

open FsUnit
open NUnit.Framework

open MockMember
open MockClaim
open TestAPI

open Account
open ManageClaims
open Repositories
    
[<Test>]
let ``load service details`` () =
    // Setup
    let viewModel = ServiceDetailsViewModel(SomeClaimId , MockClaimsRepository())

    // Test
    viewModel.LoadServiceDetails.Execute()

    // Verify
    viewModel.ServiceDetails |> should equal (Some anonymousServiceDetails)