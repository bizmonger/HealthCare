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
    let viewModel = ProvidersBySpecialtyViewModel(SomePatientId , MockProvidersRepository())
    viewModel.Specialty <- SomeSpecialty
    viewModel.Location  <- SomeOtherLocation
    viewModel.Distance  <- SomeDistance
    viewModel.Network   <- SomeNetwork

    // Test
    viewModel.Load()
    
    // Verify
    match viewModel.ValidationResult with
    | Failure _ -> failwith ""
    | _         -> ()

[<Test>]
let ``load specialties`` () = 

    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomePatientId , MockProvidersRepository())

    // Test
    viewModel.Load()
    
    // Verify
    viewModel.Specialties |> Seq.length  
                          |> should equal (SomeSpecialties |> Seq.length)

[<Test>]
let ``load networks`` () = 

    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomePatientId , MockProvidersRepository())

    // Test
    viewModel.Load()
    
    // Verify
    viewModel.Networks |> Seq.length  
                       |> should equal (SomeNetworks |> Seq.length)

[<Test>]
let ``load distances`` () = 

    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomePatientId , MockProvidersRepository())

    // Test
    viewModel.Load()
    
    // Verify
    viewModel.Distances |> Seq.length  
                        |> should equal (SomeDistances |> Seq.length)

[<Test>]
let ``search requires specialty`` () = 
    
    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomePatientId , MockProvidersRepository())
    viewModel.Specialty <- ""

    // Test
    viewModel.Load()

    // Verify
    match viewModel.ValidationResult with
    | Failure reason -> reason |> should equal SpecialtyRequired
    | _              -> failwith ""

[<Test>]
let ``search requires distance`` () = 

    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomePatientId , MockProvidersRepository())
    viewModel.Location  <- SomeOtherLocation
    viewModel.Specialty <- SomeSpecialty
    viewModel.Distance  <- 0

    // Test
    viewModel.Load()

    // Verify
    match viewModel.ValidationResult with
    | Failure reason -> reason |> should equal DistanceRequired
    | _              -> failwith ""

[<Test>]
let ``search requires network`` () = 

    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomePatientId , MockProvidersRepository())
    viewModel.Specialty <- SomeSpecialty
    viewModel.Distance  <- SomeDistance
    viewModel.Location  <- SomeOtherLocation
    viewModel.Network   <- ""

    // Test
    viewModel.Load()

    // Verify
    match viewModel.ValidationResult with
    | Failure reason -> reason |> should equal NetworkRequired
    | _              -> failwith ""

[<Test>]
let ``search requires location`` () = 

    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomePatientId , MockProvidersRepository())
    viewModel.Specialty <- SomeSpecialty
    viewModel.Distance  <- SomeDistance
    viewModel.Location  <- ""

    // Test
    viewModel.Load()

    // Verify
    match viewModel.ValidationResult with
    | Failure reason -> reason |> should equal LocationRequired
    | _              -> failwith ""