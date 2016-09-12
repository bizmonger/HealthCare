module  PlanCoverage

open FsUnit
open NUnit.Framework
open TestAPI
open MockMember
open MockOverview

open ManageBenefits
open Account

[<Test>]
let ``view your coverage`` () =
    
    // Setup
    let viewModel = CoverageViewModel(SomeMemberId , MockBenefitsRepository())

    // Test
    viewModel.LoadCoverage.Execute()

    // Verify
    viewModel.Coverage |> should equal (Some anonymousCoverage)