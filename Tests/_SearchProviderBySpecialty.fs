module  SearchProviderBySpecialty
    
open FsUnit
open NUnit.Framework
open TestAPI
open MockClaim
open MockMember
open MockProviders

open ValidationTrack
open Repositories
open Account
open ManageProviders
open FindProviders
open Validation

[<Test>]
let ``search provider`` () = 

    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomeMemberId , MockProvidersRepository())
    viewModel.Specialty <- SomeSpecialty
    viewModel.Location  <- SomeOtherLocation
    viewModel.Distance  <- SomeDistance
    viewModel.Network   <- SomeNetwork

    // Test
    viewModel.LoadProviders.Execute()
    
    // Verify
    match viewModel.ValidationResult with
    | Failure _ -> failwith ""
    | _         -> ()

[<Test>]
let ``search requires specialty`` () = 
    
    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomeMemberId , MockProvidersRepository())
    viewModel.Specialty <- ""

    // Test
    viewModel.LoadProviders.Execute()

    // Verify
    match viewModel.ValidationResult with
    | Failure reason -> reason |> should equal SpecialtyRequired
    | _              -> failwith ""

[<Test>]
let ``search requires distance`` () = 

    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomeMemberId , MockProvidersRepository())
    viewModel.Location  <- SomeOtherLocation
    viewModel.Specialty <- SomeSpecialty
    viewModel.Distance  <- 0

    // Test
    viewModel.LoadProviders.Execute()

    // Verify
    match viewModel.ValidationResult with
    | Failure reason -> reason |> should equal DistanceRequired
    | _              -> failwith ""

[<Test>]
let ``search requires network`` () = 

    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomeMemberId , MockProvidersRepository())
    viewModel.Specialty <- SomeSpecialty
    viewModel.Distance  <- SomeDistance
    viewModel.Location  <- SomeOtherLocation
    viewModel.Network   <- ""

    // Test
    viewModel.LoadProviders.Execute()

    // Verify
    match viewModel.ValidationResult with
    | Failure reason -> reason |> should equal NetworkRequired
    | _              -> failwith ""

[<Test>]
let ``search requires location`` () = 

    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomeMemberId , MockProvidersRepository())
    viewModel.Specialty <- SomeSpecialty
    viewModel.Distance  <- SomeDistance
    viewModel.Location  <- ""

    // Test
    viewModel.LoadProviders.Execute()

    // Verify
    match viewModel.ValidationResult with
    | Failure reason -> reason |> should equal LocationRequired
    | _              -> failwith ""