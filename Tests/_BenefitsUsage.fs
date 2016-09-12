﻿module BenefitsUsage

open FsUnit
open NUnit.Framework
open TestAPI
open MockMember
open MockOverview
open Account
open ManageBenefits
    
[<Test>]
let ``load in benefits usage`` () =
    
    // Setup
    let viewModel = BenefitsUsageViewModel(SomeMemberId , MockBenefitsRepository())

    // Test
    viewModel.LoadInNetworkUsage.Execute()

    // Verify
    viewModel.InNetworkUsage |> should equal anonymousUsage

[<Test>]
let ``load out of network info`` () =

    // Setup
    let viewModel = BenefitsUsageViewModel(SomeMemberId , MockBenefitsRepository())

    // Test
    viewModel.LoadOutOfNetworkUsage.Execute()

    // Verify
    viewModel.OutOfNetworkNetworkUsage |> should equal anonymousUsage

[<Test>]
let ``load members`` () =

    // Setup
    let viewModel = BenefitsUsageViewModel(SomeMemberId , MockBenefitsRepository())

    // Test
    viewModel.LoadMembers.Execute()

    // Verify
    viewModel.Members |> should equal SomeMembers