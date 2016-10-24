module Register

open FsUnit
open NUnit.Framework
open MockMember

open ValidationTrack
open InteractionLogic

open Account
open ManageAccount
open Register
open Confirmation
open Contact

[<Test>]
let ``register account`` () =

    // Setup
    let viewModel = RegisterViewModel(Dispatcher()) 
    viewModel.PatientId <- match SomeEmail with Email address -> address 
    viewModel.Password  <- SomePassword  

    // Test
    viewModel.Register.Execute()

    // Verify
    match viewModel.Form with
    | Success _ -> ()
    | _ -> failwith ""

[<Test>]
let ``successful registration dispatches result`` () =

    // Setup
    let mutable receivedSuccessNotification = false

    let dispatcher = Dispatcher()
    dispatcher.RegistrationSuccessful.Add(fun _ -> receivedSuccessNotification <- true)
    let viewModel = RegisterViewModel(dispatcher)
    
    viewModel.PatientId <- match SomeEmail with Email address -> address 
    viewModel.Password  <- SomePassword  

    // Test
    viewModel.Register.Execute()

    // Verify
    receivedSuccessNotification |> should equal true

[<Test>]
let ``registration failed: missing PatientId`` () =

    // Setup
    let viewModel = RegisterViewModel(Dispatcher())
    viewModel.PatientId     <- ""

    // Test
    viewModel.Register.Execute()

    // Verify
    match viewModel.Form with
    | Failure reason -> reason |> should equal PatientIdRequired
    | _ -> failwith ""

[<Test>]
let ``registration failed: missing password`` () =

    // Setup
    let viewModel = RegisterViewModel(Dispatcher())
    viewModel.PatientId     <- match SomeEmail with Email address -> address 
    viewModel.Password  <- ""

    // Test
    viewModel.Register.Execute()

    // Verify
    match viewModel.Form with
    | Failure reason -> reason |> should equal PasswordRequired
    | _ -> failwith ""

[<Test>]
let ``display try again interface`` () =
    
    // Setup
    let viewModel = RegisterViewModel(Dispatcher())
    let mutable interfaceRequested = false
    viewModel.TryAgainConfirmation.Show.Add(fun _ -> interfaceRequested <- true)

    // Test
    viewModel.Register.Execute()

    // Verify
    interfaceRequested |> should equal true

[<Test>]
let ``PatientId tries again`` () =

    // Setup
    let viewModel = RegisterViewModel(Dispatcher())

    viewModel.TryAgainConfirmation.Show.Add(fun _ ->
        viewModel.PatientId <- match SomeEmail with Email address -> address   
        viewModel.Password  <- SomePassword  
        viewModel.Register.Execute())

    // Test
    viewModel.Register.Execute()

    // Verify
    match viewModel.Form with
    | Success f -> ()
    | Failure r -> failwith ""

[<Test>]
let ``PatientId cancels attempt`` () = 

    // Setup
    let viewModel = RegisterViewModel(Dispatcher())

    viewModel.TryAgainConfirmation.Show.Add(fun _ -> ())

    // Test
    viewModel.Register.Execute()

    // Verify
    match viewModel.Form with
    | Success f -> failwith ""
    | Failure r -> ()