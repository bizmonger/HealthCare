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
    viewModel.LoadFamilySummary()

    // Verify
    viewModel.FamilySummary |> should equal SomeFamilyClaimsSummary

[<Test>]
let ``get total insurance savings`` () =

    // Setup
    let anonymousFamilySummary = { 
        Claims=SomeClaims
        ProvidersCharged=SomeProvidersCharged
        InsuranceSavings=SomeInsuranceSavings }

    let providersCharged = match anonymousFamilySummary.ProvidersCharged with 
                            | ProvidersCharged pc -> pc

    let insuranceSavings = match anonymousFamilySummary.InsuranceSavings with
                            | InsuranceSavings is -> is

    // Test
    anonymousFamilySummary.TotalSavings() |> should equal (providersCharged - insuranceSavings)

[<Test>]
let ``load dependent claims summary`` () =

    // Setup
    let viewModel = ClaimsSummaryViewModel(SomeMemberId , MockClaimsRepository())

    // Test
    viewModel.LoadMemberSummaries()

    // Verify
    viewModel.DependentSummaries |> should equal SomeDependentSummaries