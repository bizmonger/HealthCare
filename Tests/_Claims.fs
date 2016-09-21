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
open InteractionLogic
open System.Linq
    
[<Test>]
let ``load family claims summary`` () =

    // Setup
    let viewModel = ClaimsSummaryViewModel(SomeMemberId , Dispatcher() , MockClaimsRepository())

    // Test
    viewModel.LoadFamilySummary()

    // Verify
    viewModel.FamilySummary |> should equal SomeFamilySummary

[<Test>]
let ``get total insurance savings`` () =

    // Setup
    let anonymousFamilySummary = {
        Member = SomeIdCard
        Claims=SomeClaims
        ProvidersCharged=SomeProvidersCharged
        InsuranceSavings=SomeInsuranceSavings }

    let providersCharged = match anonymousFamilySummary.ProvidersCharged with 
                            | ProvidersCharged v -> v

    let insuranceSavings = match anonymousFamilySummary.InsuranceSavings with
                            | InsuranceSavings v -> v

    // Test
    anonymousFamilySummary.TotalSavings() |> should equal (providersCharged - insuranceSavings)

[<Test>]
let ``load dependent claims summary`` () =

    // Setup
    let viewModel = ClaimsSummaryViewModel(SomeMemberId , Dispatcher() , MockClaimsRepository())

    // Test
    viewModel.LoadMemberSummaries()

    // Verify
    viewModel.DependentSummaries |> should equal SomeDependentSummaries

[<Test>]
let ``navigate to member claims`` () =

    // Setup
    let mutable claimsRequested = false
    let dispatcher = Dispatcher()
    dispatcher.MemberClaimsRequested.Add (fun _ -> claimsRequested <- true)
    let viewModel = ClaimsSummaryViewModel(SomeMemberId , dispatcher , MockClaimsRepository())

    // Test
    viewModel.OnSummarySelected (viewModel.DependentSummaries.First())

    // Verify
    claimsRequested |> should equal true