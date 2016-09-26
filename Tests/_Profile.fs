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
    viewModel.Load()

    // Verify
    viewModel.Dependents |> should equal [SomeProfile ; SomeProfile ; SomeProfile]

[<Test>]
let ``view dependent`` () =

    // Setup
    let mutable profileRequested = false
    let dispatcher = Dispatcher()
    dispatcher.ProfileRequested.Add (fun _ -> profileRequested <- true)
    let viewModel = ProfileViewModel(SomeMemberId , dispatcher , MockProfileRepository())
    viewModel.Load();

    // Test
    viewModel.Dependent <- Some viewModel.Dependents.Head;
    viewModel.ViewDependent.Execute();

    // Verify
    profileRequested |> should equal true

[<Test>]
let ``load profile info`` () =

    // Setup
    let viewModel = ProfileViewModel(SomeMemberId , Dispatcher() , MockProfileRepository())

    // Test
    viewModel.Load()

    // Verify
    viewModel.Profile |> should equal (Some SomeProfile)