module  ClaimsDetail

open FsUnit
open NUnit.Framework

open MockMember
open MockClaim
open TestAPI
open InteractionLogic

open Account
open ManageClaims
open Repositories
    
[<Test>]
let ``load claim`` () =

    // Setup
    let viewModel = ClaimsDetailViewModel(SomeClaimId , Dispatcher() , MockClaimsRepository())

    // Test
    viewModel.LoadClaim.Execute()

    // Verify
    viewModel.Claim |> should equal (Some anonymousClaim)

[<Test>]
let ``load payment summary`` () =

    // Setup
    let viewModel = ClaimsDetailViewModel(SomeClaimId , Dispatcher() , MockClaimsRepository())

    // Test
    viewModel.LoadPaymentSummary.Execute()

    // Verify
    viewModel.PaymentSummary |> should equal (Some mockPaymentSummary)

[<Test>]
let ``view service details`` () =
    
    // Setup
    let mutable serviceDetailsRequested = false
    let dispatcher = Dispatcher()
    dispatcher.ServiceDetailsRequested.Add(fun _ -> serviceDetailsRequested <- true)
    let viewModel = ClaimsDetailViewModel(SomeClaimId , dispatcher , MockClaimsRepository())

    // Test
    viewModel.ViewServiceDetails.Execute();

    // Verify
    serviceDetailsRequested |> should equal true

[<Test>]
let ``view payment details`` () =
    
    // Setup
    let mutable paymentDetailsRequested = false
    let dispatcher = Dispatcher()
    dispatcher.PaymentDetailsRequested.Add(fun _ -> paymentDetailsRequested <- true)
    let viewModel = ClaimsDetailViewModel(SomeClaimId , dispatcher , MockClaimsRepository())

    // Test
    viewModel.ViewPaymentDetails.Execute();

    // Verify
    paymentDetailsRequested |> should equal true