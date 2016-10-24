module  PersonalProfile

open FsUnit
open NUnit.Framework
open MockMember
open TestAPI

open Account
open ManageAccount
open Repositories
open Contact

[<Test>]
let ``edit profile's email`` () = 

    // Setup
    let repository = MockProfileRepository() :> IProfileRepository
    let viewModel =  EditProfileViewModel(SomePatientId , repository)

    viewModel.SSN     <- match SomeSSN     with SSN     v -> v.ToString()
    viewModel.ZipCode <- match SomeZipCode with ZipCode v -> v.ToString()
    viewModel.Email   <- match SomeEmail   with Email   v -> v
    viewModel.Save.Execute()

    // Test
    viewModel.Email <- "edited@abc.com"
    viewModel.Save.Execute()
    

    // Verify
    let updatedProfile = repository.GetProfile SomePatientId
    match updatedProfile with
    | Some p ->  match p.Email with
                 | Email v when v = "edited@abc.com" -> ()
                 | _ -> failwith ""
    | _              -> failwith ""

[<Test>]
let ``edit profile's address`` () = 

    // Setup
    let repository = MockProfileRepository() :> IProfileRepository
    let viewModel =  EditProfileViewModel(SomePatientId , repository)

    viewModel.SSN      <- match SomeSSN     with SSN     v -> v.ToString()
    viewModel.ZipCode  <- match SomeZipCode with ZipCode v -> v.ToString()
    viewModel.Address1 <- "some_address1"
    viewModel.Save.Execute()

    // Test
    viewModel.Address1 <- "some_updated_address"
    viewModel.Save.Execute()
    

    // Verify
    let updatedProfile = repository.GetProfile SomePatientId
    match updatedProfile with
    | Some p ->  match p.Address.Address1 with
                 | Street "some_updated_address" -> ()
                 | _ -> failwith ""
    | _              -> failwith ""