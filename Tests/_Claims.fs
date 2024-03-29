﻿module Claims

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
    
[<Test>]
let ``load family claims summary`` () =

    // Setup
    let viewModel = ClaimsSummaryViewModel(SomePatientId , Dispatcher() , MockClaimsRepository())

    // Test
    viewModel.Load()

    // Verify
    viewModel.FamilySummary |> should equal (Some SomeFamilySummary)

[<Test>]
let ``load member claims`` () =

    // Setup
    let viewModel = MemberClaimsSummaryViewModel(SomePatientId , Dispatcher() , MockClaimsRepository())

    // Test
    viewModel.Load()

    // Verify
    viewModel.Claims |> should equal SomeClaims

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
    let viewModel = ClaimsSummaryViewModel(SomePatientId , Dispatcher() , MockClaimsRepository())

    // Test
    viewModel.Load()

    // Verify
    viewModel.DependentSummaries |> should equal SomeDependentSummaries

[<Test>]
let ``navigate to member claims`` () =

    // Setup
    let mutable claimsRequested = false
    let dispatcher = Dispatcher()
    dispatcher.MemberClaimsRequested.Add (fun _ -> claimsRequested <- true)

    let viewModel = ClaimsSummaryViewModel(SomePatientId , dispatcher , MockClaimsRepository())
    viewModel.Load();

    viewModel.DependentSummary <- Some (Seq.head viewModel.DependentSummaries)

    // Test
    viewModel.ViewClaims.Execute()

    // Verify
    claimsRequested |> should equal true