module Account

open FsUnit
open NUnit.Framework
open TestAPI
open MockMember

open InteractionLogic
open ManageAccount
open Home
open TestAPI


[<Test>]
let ``navigate to account info`` () =

    // Setup
    let mutable accountRequested = false
    let dispatcher = Dispatcher()
    dispatcher.AccountRequested.Add(fun _ -> accountRequested <- true)
    let viewModel = MenuViewModel(SomePatientId , dispatcher)

    // Test
    viewModel.ViewAccount.Execute()

    // Verify
    accountRequested |> should equal true

[<Test>]
let ``view profile`` () =

    // Setup
    let mutable profileRequested = false
    let dispatcher = Dispatcher()
    dispatcher.ProfileRequested.Add(fun _ -> profileRequested <- true)
    let viewModel = AccountViewModel(SomePatientId , dispatcher)

    // Test
    viewModel.ViewProfile.Execute()

    // Verify
    profileRequested |> should equal true

[<Test>]
let ``view dependents profile`` () =

    // Setup
    let mutable dependentProfilesRequested = false
    let dispatcher = Dispatcher()
    dispatcher.DependentProfilesRequested.Add(fun _ -> dependentProfilesRequested <- true)
    let viewModel = AccountViewModel(SomePatientId , dispatcher)

    // Test
    viewModel.ViewDependentProfiles.Execute()

    // Verify
    dependentProfilesRequested |> should equal true

[<Test>]
let ``login settings`` () =

    // Setup
    let mutable loginSettingsRequested = false
    let dispatcher = Dispatcher()
    dispatcher.LoginSettingsRequested.Add(fun _ -> loginSettingsRequested <- true)
    let viewModel = AccountViewModel(SomePatientId , dispatcher)

    // Test
    viewModel.ViewLoginSettings.Execute()

    // Verify
    loginSettingsRequested |> should equal true