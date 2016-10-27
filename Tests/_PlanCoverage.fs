module  PlanCoverage

open FsUnit
open NUnit.Framework
open TestAPI
open MockMember

open ManageBenefits
open Account

[<Test>]
let ``view your services`` () =
    
    // Setup
    let viewModel = CoverageViewModel(SomeCompanyId , SomePatientId , MockBenefitsRepository())

    // Test
    viewModel.Load()

    // Verify
    viewModel.Services |> should equal SomeServices