module  IDCard

open FsUnit
open NUnit.Framework
open MockMember

open InteractionLogic
open ManageAccount
open Account
open Repositories
open Settings
open Repositories
open Home

[<Test>]
let ``print id card`` () =

    // Setup
    let mutable printRequested = false
    let dispatcher = Dispatcher()
    dispatcher.PrintIdRequested.Add(fun _ -> printRequested <- true)
    let viewModel = IdCardViewModel(SomeIdCard , dispatcher)
    
    // Test
    viewModel.Print.Execute()

    // Verify
    printRequested |> should equal true

[<Test>]
let ``email id card`` () =

    // Setup
    let mutable emailRequested = false
    let dispatcher = Dispatcher()
    dispatcher.EmailIdRequested.Add(fun _ -> emailRequested <- true)
    let viewModel = IdCardViewModel(SomeIdCard , dispatcher)

    // Test
    viewModel.Email.Execute()

    // Verify
    emailRequested |> should equal true

[<Test>]
let ``enable id card viewing for home screen`` () =

    // Setup
    let dispatcher = Dispatcher()
    let homeViewModel = HomeViewModel(dispatcher)
    let cardViewModel = IdCardViewModel(SomeIdCard , dispatcher)

    // Test
    cardViewModel.EnableHomeAccess.Execute()

    // Verify
    homeViewModel.Settings.ViewIdCardFromHome |> should equal true