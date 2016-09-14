module  SearchProviderBySpecialty
    
open FsUnit
open NUnit.Framework
open TestAPI
open MockClaim
open MockMember

open Repositories
open Account
open ManageProviders

let SomeSpecialty =    "some_specialty"
let CurrentLocation =  "current location"
let SomeOtherAddress = "some_other_address"

[<Test>]
let ``search provider from current location`` () =

    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomeMemberId , MockProvidersRepository())
    viewModel.Specialty <- SomeSpecialty
    viewModel.Location  <- CurrentLocation

    // Test
    viewModel.LoadProviders.Execute()
    
    // Verify 
    viewModel.Providers |> should equal [SomeProvider]

[<Test>]
let ``search provider from another address`` () = 

    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomeMemberId , MockProvidersRepository())
    viewModel.Specialty <- SomeSpecialty
    viewModel.Location  <- SomeOtherAddress

    // Test
    viewModel.LoadProviders.Execute()
    
    // Verify 
    viewModel.Providers |> should equal [SomeProvider]

[<Test>]
let ``search provider by specialty`` () = 

    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomeMemberId , MockProvidersRepository())
    viewModel.Specialty <- SomeSpecialty
    viewModel.Location  <- SomeOtherAddress

    // Test
    viewModel.LoadProviders.Execute()
    
    // Verify 
    viewModel.Providers |> should equal [SomeProvider]

[<Test>]
let ``search requires specialty`` () = 
    
    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomeMemberId , MockProvidersRepository())
    viewModel.Specialty <- ""

    // Test
    viewModel.LoadProviders.Execute()

    // Verify
    viewModel.ValidationResult |> should equal SomeProviders

[<Test>]
let ``search requires distance`` () = 

    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomeMemberId , MockProvidersRepository())
    viewModel.Specialty <- "some_specialty"
    viewModel.Distance  <- "50"

    // Test
    viewModel.LoadProviders.Execute()

    // Verify
    viewModel.ValidationResult |> should equal SomeProviders

[<Test>]
let ``search requires network`` () = 

    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomeMemberId , MockProvidersRepository())
    viewModel.Specialty <- "some_specialty"
    viewModel.Distance  <- "50"
    viewModel.Network   <- "some_network"

    // Test
    viewModel.LoadProviders.Execute()

    // Verify
    viewModel.ValidationResult |> should equal SomeProviders

[<Test>]
let ``search requires location`` () = 

    // Setup
    let viewModel = ProvidersBySpecialtyViewModel(SomeMemberId , MockProvidersRepository())
    viewModel.Specialty <- "some_specialty"
    viewModel.Distance  <- "50"
    viewModel.Location  <- ""

    // Test
    viewModel.LoadProviders.Execute()

    // Verify
    viewModel.ValidationResult |> should equal SomeProviders