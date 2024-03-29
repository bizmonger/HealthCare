﻿module PortalDashboard

open FsUnit
open NUnit.Framework
open MockMember
open TestAPI
open InteractionLogic
open Home


[<Test>]
let ``load last appointment info`` () =
    
    // Setup
    let viewModel = PortalViewModel(SomePatientId , Dispatcher() , MockBenefitsRepository())

    // Test
    viewModel.Load()

    // Verify
    viewModel.LastAppointment |> should equal (Some SomeAppointment)

[<Test>]
let ``navigate to id card`` () =

    // Setup
    let mutable idCardRequested = false
    let dispatcher = Dispatcher()
    dispatcher.IdRequested.Add (fun _ -> idCardRequested <- true)
    let viewModel = PortalViewModel(SomePatientId , dispatcher , MockBenefitsRepository())

    // Test
    viewModel.ViewIdCard.Execute()

    // Verify
    idCardRequested |> should equal true

[<Test>]
let ``navigate to benefits`` () =

    // Setup
    let mutable benefitsRequested = false
    let dispatcher = Dispatcher()
    dispatcher.CoverageRequested.Add (fun _ -> benefitsRequested <- true)
    let viewModel = PortalViewModel(SomePatientId , dispatcher , MockBenefitsRepository())

    // Test
    viewModel.ViewBenefits.Execute()

    // Verify
    benefitsRequested |> should equal true

[<Test>]
let ``navigate to providers`` () =

    // Setup
    let mutable providersRequested = false
    let dispatcher = Dispatcher()
    dispatcher.FindProvidersRequested.Add (fun _ -> providersRequested <- true)
    let viewModel = PortalViewModel(SomePatientId , dispatcher , MockBenefitsRepository())

    // Test
    viewModel.ViewProviders.Execute()

    // Verify
    providersRequested |> should equal true

[<Test>]
let ``navigate to family claims`` () =

    // Setup
    let mutable claimsRequested = false
    let dispatcher = Dispatcher()
    dispatcher.FamilyClaimsRequested.Add (fun _ -> claimsRequested <- true)
    let viewModel = PortalViewModel(SomePatientId , dispatcher , MockBenefitsRepository())

    // Test
    viewModel.ViewFamilyClaims.Execute()

    // Verify
    claimsRequested |> should equal true