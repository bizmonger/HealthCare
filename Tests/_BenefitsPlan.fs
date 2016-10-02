module BenefitsPlan

open FsUnit
open MockMember
open NUnit.Framework
open InteractionLogic
open ManageBenefits
open TestAPI

[<Test>]
let ``view in network`` () =
    
    // Setup
    let mutable inNetworkRequested = false
    let dispatcher = Dispatcher()
    dispatcher.InNetworkRequested.Add(fun _ -> inNetworkRequested <- true)
    let viewModel = new BenefitsPlanViewModel(SomeMemberId , dispatcher, MockBenefitsRepository())

    // Test
    viewModel.ViewInNetwork.Execute()

    // Verify
    inNetworkRequested |> should equal true

[<Test>]
let ``view out of network`` () =

    // Setup
    let mutable outOfNetworkRequested = false
    let dispatcher = Dispatcher()
    dispatcher.OutOfNetworkRequested.Add(fun _ -> outOfNetworkRequested <- true)
    let viewModel = new BenefitsPlanViewModel(SomeMemberId , dispatcher, MockBenefitsRepository())

    // Test
    viewModel.ViewOutOfNetwork.Execute()

    // Verify
    outOfNetworkRequested |> should equal true

[<Test>]
let ``view preventive and diagnostic`` () =

    // Setup
    let mutable preventiveAndDiagnosticRequested = false
    let dispatcher = Dispatcher()
    dispatcher.PreventiveAndDiagnosticsRequested.Add(fun _ -> preventiveAndDiagnosticRequested <- true)
    let viewModel = new BenefitsPlanViewModel(SomeMemberId , dispatcher, MockBenefitsRepository())

    // Test
    viewModel.ViewPreventiveAndDiagnostic.Execute()

    // Verify
    preventiveAndDiagnosticRequested |> should equal true

[<Test>]
let ``view restoration`` () =

    // Setup
    let mutable restorationRequested = false
    let dispatcher = Dispatcher()
    dispatcher.RestorationRequested.Add(fun _ -> restorationRequested <- true)
    let viewModel = new BenefitsPlanViewModel(SomeMemberId , dispatcher, MockBenefitsRepository())

    // Test
    viewModel.ViewRestoration.Execute()

    // Verify
    restorationRequested |> should equal true

[<Test>]
let ``view oral surgery`` () =

    // Setup
    let mutable oralSurgeryRequested = false
    let dispatcher = Dispatcher()
    dispatcher.OralSurgeryRequested.Add(fun _ -> oralSurgeryRequested <- true)
    let viewModel = new BenefitsPlanViewModel(SomeMemberId , dispatcher, MockBenefitsRepository())

    // Test
    viewModel.ViewOralSurgery.Execute()

    // Verify
    oralSurgeryRequested |> should equal true

[<Test>]
let ``view periodontics`` () =

    // Setup
    let mutable periodonticsRequested = false
    let dispatcher = Dispatcher()
    dispatcher.PeriodonticsRequested.Add(fun _ -> periodonticsRequested <- true)
    let viewModel = new BenefitsPlanViewModel(SomeMemberId , dispatcher, MockBenefitsRepository())

    // Test
    viewModel.ViewPeriodontics.Execute()

    // Verify
    periodonticsRequested |> should equal true

[<Test>]
let ``load viewmodel`` () =

    // Setup
    let viewModel = new BenefitsPlanViewModel(SomeMemberId , Dispatcher(), MockBenefitsRepository())

    // Test
    viewModel.Load()

    // Verify
    viewModel.Summary |> should equal (Some anonymousSummary)