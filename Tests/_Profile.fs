module Profile
 
open FsUnit
open NUnit.Framework
open TestAPI
open MockMember

open InteractionLogic

open Repositories
open Account
open ManageAccount
  
[<Test>]
let ``load dependents info`` () =

    // Setup
    let viewModel = ProfileViewModel(SomeMemberId , Dispatcher() , MockProfileRepository())

    // Test
    viewModel.LoadDependents.Execute()

    // Verify
    viewModel.Dependents |> should equal [SomeProfile]

[<Test>]
let ``view dependent`` () =

    // Setup
    let mutable profileRequested = false
    let dispatcher = Dispatcher()
    dispatcher.ProfileRequested.Add (fun _ -> profileRequested <- true)
    let viewModel = ProfileViewModel(SomeMemberId , dispatcher , MockProfileRepository())

    // Test
    viewModel.ViewProfile.Execute()

    // Verify
    profileRequested |> should equal true

[<Test>]
let ``load profile info`` () =

    // Setup
    let viewModel = ProfileViewModel(SomeMemberId , Dispatcher() , MockProfileRepository())

    // Test
    viewModel.LoadProfile.Execute()

    // Verify
    viewModel.Profile |> should equal (Some SomeProfile)