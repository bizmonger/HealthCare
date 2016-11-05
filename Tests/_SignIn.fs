module  SignIn
    
open FsUnit
open NUnit.Framework
open MockMember

open InteractionLogic
open ValidationTrack
open ManageAccount
open SignIn
open Account

[<Test>]
let ``sign into account`` () =

    // Setup
    let viewModel = SignInViewModel(Dispatcher())
    viewModel.PatientId <- match SomePatientId with PatientId v -> v  
    viewModel.Password  <- SomePassword

    // Test
    viewModel.SignIn.Execute()

    // Verify
    match viewModel.Form with
    | Failure reason -> failwith ""
    | Success _ -> ()

[<Test>]
let ``signin failed: PatientId required`` () =

    // Setup
    let viewModel = SignInViewModel(Dispatcher())
    viewModel.PatientId <- ""
    viewModel.Password  <- SomePassword

    // Test
    viewModel.SignIn.Execute()

    // Verify
    match viewModel.Form with
    | Failure reason -> reason |> should equal PatientIdRequired
    | _              -> failwith ""

[<Test>]
let ``signin failed: password required`` () =
    
    // Setup
    let viewModel = SignInViewModel(Dispatcher())
    viewModel.PatientId <- match SomePatientId with PatientId v -> v 
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
let ``PatientId tries again`` () =

    // Setup
    let viewModel = SignInViewModel(Dispatcher())

    viewModel.TryAgainConfirmation.Show.Add(fun _ ->
        viewModel.PatientId <- match SomePatientId with PatientId v -> v   
        viewModel.Password  <- SomePassword  
        viewModel.SignIn.Execute())

    // Test
    viewModel.SignIn.Execute()

    // Verify
    match viewModel.Form with
    | Success f -> ()
    | Failure r -> failwith ""

[<Test>]
let ``PatientId cancels attempt`` () =

    // Setup
    let viewModel = SignInViewModel(Dispatcher())

    viewModel.TryAgainConfirmation.Show.Add(fun _ -> ())

    // Test
    viewModel.SignIn.Execute()

    // Verify
    match viewModel.Form with
    | Success f -> failwith ""
    | Failure r -> ()