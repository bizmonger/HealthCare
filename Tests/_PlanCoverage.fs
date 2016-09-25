module  PlanCoverage

open FsUnit
open NUnit.Framework
open TestAPI
open MockMember

open ManageBenefits
open Account

[<Test>]
let ``view your coverage`` () =
    
    // Setup
    let viewModel = CoverageViewModel(SomeMemberId , MockBenefitsRepository())

    // Test
    viewModel.Load()

    // Verify
    viewModel.MemberCoverages |> should equal SomeMemberCoverages