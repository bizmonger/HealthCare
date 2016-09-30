module BenefitsUsage

open FsUnit
open NUnit.Framework
open TestAPI
open MockMember
open Account
open ManageBenefits
    
[<Test>]
let ``load in benefits usage`` () =
    
    // Setup
    let viewModel = BenefitsUsageViewModel(SomeMemberId , MockBenefitsRepository())

    // Test
    viewModel.Load()

    // Verify
    viewModel.InNetworkUsage |> should equal (Some anonymousUsage)

[<Test>]
let ``load out of network info`` () =

    // Setup
    let viewModel = BenefitsUsageViewModel(SomeMemberId , MockBenefitsRepository())

    // Test
    viewModel.Load()

    // Verify
    viewModel.OutOfNetworkNetworkUsage |> should equal (Some anonymousUsage)

[<Test>]
let ``load members`` () =

    // Setup
    let viewModel = BenefitsUsageViewModel(SomeMemberId , MockBenefitsRepository())

    // Test
    viewModel.Load()

    // Verify
    viewModel.Members |> should equal SomeMemberCoverages