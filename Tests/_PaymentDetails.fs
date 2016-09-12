module PaymentDetails

open FsUnit
open NUnit.Framework

open MockMember
open MockClaim
open TestAPI

open Account
open ManageClaims
open Repositories
    
[<Test>]
let ``load payment details`` () =

    // Setup
    let viewModel = PaymentDetailsViewModel(SomeClaimId , MockClaimsRepository())

    // Test
    viewModel.LoadPaymentDetails.Execute()

    // Verify
    viewModel.PaymentDetails |> should equal (Some anonymousPaymentDetails)