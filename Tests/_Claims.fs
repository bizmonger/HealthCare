module Claims

open FsUnit
open NUnit.Framework
open TestAPI
open MockMember
open MockClaim
open ManageClaims
open Account
open Claims
open Repositories
    
[<Test>]
let ``load family claims summary`` () =

    // Setup
    let viewModel = ClaimsSummaryViewModel(SomeMemberId , MockClaimsRepository())

    // Test
    viewModel.LoadFamilySummary.Execute()

    // Verify
    viewModel.FamilySummary |> should equal SomeFamilyClaimsSummary

[<Test>]
let ``load dependent claims summary`` () =

    // Setup
    let viewModel = ClaimsSummaryViewModel(SomeMemberId , MockClaimsRepository())

    // Test
    viewModel.LoadMemberSummaries.Execute()

    // Verify
    viewModel.DependentSummaries |> should equal SomeDependentSummaries