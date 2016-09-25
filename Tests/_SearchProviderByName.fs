module  SearchProviderByName
    
open FsUnit
open NUnit.Framework
open MockMember
open MockClaim
open TestAPI

open ValidationTrack
open Repositories
open Account
open ManageProviders
open FindProviders
open Claims

[<Test>]
let ``search provider by name`` () =
    
    // Setup
    let viewModel = ProvidersByNameViewModel(SomeMemberId , MockProvidersRepository())
    viewModel.FirstName  <- SomeFirstName
    viewModel.MiddleName <- None
    viewModel.LastName   <- SomeLastName
    viewModel.Office     <- match SomeOffice with Office v -> v

    // Test
    viewModel.Load()

    // Verify
    viewModel.Providers |> should equal SomeProviders

[<Test>]
let ``search requires first name`` () =

    // Setup
    let viewModel = ProvidersByNameViewModel(SomeMemberId , MockProvidersRepository())
    viewModel.FirstName  <- ""
    viewModel.MiddleName <- None
    viewModel.LastName   <- SomeLastName
    viewModel.Office     <- match SomeOffice with Office v -> v

    // Test
    viewModel.Validate()

    // Verify
    match viewModel.ValidationResult with
    | Success _ -> failwith ""
    | Failure reason -> reason |> should equal FirstNameRequired

[<Test>]
let ``search requires last name`` () =

    // Setup
    let viewModel = ProvidersByNameViewModel(SomeMemberId , MockProvidersRepository())
    viewModel.FirstName  <- SomeFirstName
    viewModel.MiddleName <- None
    viewModel.LastName   <- ""
    viewModel.Office     <- match SomeOffice with Office v -> v

    // Test
    viewModel.Validate()

    // Verify
    match viewModel.ValidationResult with
    | Success _ -> failwith ""
    | Failure reason -> reason |> should equal LastNameRequired

[<Test>]
let ``search requires office name`` () =

    // Setup
    let viewModel = ProvidersByNameViewModel(SomeMemberId , MockProvidersRepository())
    viewModel.FirstName  <- SomeFirstName
    viewModel.MiddleName <- None
    viewModel.LastName   <- SomeLastName
    viewModel.Office     <- ""

    // Test
    viewModel.Validate()

    // Verify
    match viewModel.ValidationResult with
    | Success _ -> failwith ""
    | Failure reason -> reason |> should equal OfficeRequired
    

