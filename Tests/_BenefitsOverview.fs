module Benefits

open FsUnit
open NUnit.Framework

open InteractionLogic
open Repositories
open Benefits
open ManageBenefits
open Account
open MockMember
open TestAPI

[<Test>]
let ``load benefits summary`` () =

    // Setup
    let viewModel = BenefitsOverviewViewModel(SomeMemberId, MockBenefitsRepository(), Dispatcher())

    // Test
    viewModel.Load()

    // Verify
    viewModel.Overview.Value.Coverage.Member.Name |> should equal SomeName

[<Test>]
let ``view benefits plan benefits`` () =
    
    // Setup
    let mutable planRequested = false
    let dispatcher = Dispatcher()
    dispatcher.PlanRequested.Add (fun _ -> planRequested <- true)

    let viewModel =  BenefitsOverviewViewModel(SomeMemberId, MockBenefitsRepository(), dispatcher)
    viewModel.Load()

    // Test
    viewModel.ViewPlan.Execute()

    // Verify
    planRequested |> should equal true

[<Test>]
let ``view benefits coverage`` () =
    
    // Setup
    let mutable coverageRequested = false
    let dispatcher = Dispatcher()
    dispatcher.CoverageRequested.Add (fun _ -> coverageRequested <- true)

    let viewModel =  BenefitsOverviewViewModel(SomeMemberId, MockBenefitsRepository(), dispatcher)
    viewModel.Load()

    // Test
    viewModel.ViewCoverage.Execute()

    // Verify
    coverageRequested |> should equal true

[<Test>]
let ``view benefits usage`` () =

    // Setup
    let mutable usageRequested = false
    let dispatcher = Dispatcher()
    dispatcher.UsageRequested.Add (fun _ -> usageRequested <- true)

    let viewModel =  BenefitsOverviewViewModel(SomeMemberId, MockBenefitsRepository(), dispatcher)
    viewModel.Load()

    // Test
    viewModel.ViewUsage.Execute()

    // Verify
    usageRequested |> should equal true
    

