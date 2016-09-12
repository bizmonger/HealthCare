module  SignIn
    
open FsUnit
open NUnit.Framework
open MockMember

open InteractionLogic
open ValidationTrack
open ManageAccount
open SignIn

[<Test>]
let ``sign into account`` () =

    // Setup
    let viewModel = SignInViewModel(Dispatcher())
    viewModel.UserName <- SomeUser    
    viewModel.Password <- SomePassword

    // Test
    viewModel.SignIn.Execute()

    // Verify
    match viewModel.Form with
    | Failure reason -> failwith ""
    | Success _ -> ()

[<Test>]
let ``signin failed: username required`` () =

    // Setup
    let viewModel = SignInViewModel(Dispatcher())
    viewModel.UserName <- ""
    viewModel.Password <- SomePassword

    // Test
    viewModel.SignIn.Execute()

    // Verify
    match viewModel.Form with
    | Failure reason -> reason |> should equal UserNameRequired
    | _ -> failwith ""

[<Test>]
let ``signin failed: password required`` () =
    
    // Setup
    let viewModel = SignInViewModel(Dispatcher())
    viewModel.UserName <- SomeUser
    viewModel.Password <- ""

    // Test
    viewModel.SignIn.Execute()
    
    // Verify 
    match viewModel.Form with
    | Failure reason -> reason |> should equal PasswordRequired
    | _ -> failwith ""

[<Test>]
let ``display try again interface`` () =

    // Setup
    let viewModel = SignInViewModel(Dispatcher())
    let mutable interfaceRequested = false
    viewModel.TryAgainConfirmation.Show.Add(fun _ -> interfaceRequested <- true)

    // Test
    viewModel.SignIn.Execute()

    // Verify
    interfaceRequested |> should equal true

[<Test>]
let ``user tries again`` () =

    // Setup
    let viewModel = SignInViewModel(Dispatcher())

    viewModel.TryAgainConfirmation.Show.Add(fun _ ->
        viewModel.UserName <- SomeUser   
        viewModel.Password <- SomePassword  
        viewModel.SignIn.Execute())

    // Test
    viewModel.SignIn.Execute()

    // Verify
    match viewModel.Form with
    | Success f -> ()
    | Failure r -> failwith ""

[<Test>]
let ``user cancels attempt`` () =

    // Setup
    let viewModel = SignInViewModel(Dispatcher())

    viewModel.TryAgainConfirmation.Show.Add(fun _ -> ())

    // Test
    viewModel.SignIn.Execute()

    // Verify
    match viewModel.Form with
    | Success f -> failwith ""
    | Failure r -> ()