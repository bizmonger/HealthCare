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

[<Test>]
let ``register account`` () =

    // Setup
    let viewModel = RegisterViewModel(Dispatcher())
    viewModel.FirstName   <- SomeFirstName
    viewModel.LastName    <- SomeLastName
    viewModel.DateOfBirth <- SomeDateOfBirth 
    viewModel.Email       <- match SomeEmail with Email address -> address 
    viewModel.Password    <- SomePassword  
    viewModel.Zipcode     <- match SomeZipCode with ZipCode zip -> zip

    // Test
    viewModel.Register.Execute()

    // Verify
    match viewModel.Form with
    | Success _ -> ()
    | _ -> failwith ""

[<Test>]
let ``successful registration dispatches result`` () =

    // Setup
    let mutable recievedSuccessNotification = false

    let dispatcher = Dispatcher()
    dispatcher.RegistrationSuccessful.Add(fun _ -> recievedSuccessNotification <- true)
    let viewModel = RegisterViewModel(dispatcher)
    
    viewModel.FirstName   <- SomeFirstName
    viewModel.LastName    <- SomeLastName
    viewModel.DateOfBirth <- SomeDateOfBirth 
    viewModel.Email       <- match SomeEmail with Email address -> address 
    viewModel.Password    <- SomePassword  
    viewModel.Zipcode     <- match SomeZipCode with ZipCode zip -> zip

    // Test
    viewModel.Register.Execute()

    // Verify
    recievedSuccessNotification |> should equal true

[<Test>]
let ``registration failed: missing first name`` () =

    // Setup
    let viewModel = RegisterViewModel(Dispatcher())
    viewModel.FirstName <- ""

    // Test
    viewModel.Register.Execute()

    // Verify
    match viewModel.Form with
    | Failure reason -> reason |> should equal FirstNameRequired
    | _ -> failwith ""

[<Test>]
let ``registration failed: missing last name`` () =

    // Setup
    let viewModel = RegisterViewModel(Dispatcher())
    viewModel.FirstName <- SomeFirstName
    viewModel.LastName  <- ""

    // Test
    viewModel.Register.Execute()

    // Verify
    match viewModel.Form with
    | Failure reason -> reason |> should equal LastNameRequired
    | _ -> failwith ""

[<Test>]
let ``registration failed: missing memberId`` () =

    // Setup
    let viewModel = RegisterViewModel(Dispatcher())
    viewModel.FirstName <- SomeFirstName
    viewModel.LastName  <- SomeLastName
    viewModel.Email     <- ""

    // Test
    viewModel.Register.Execute()

    // Verify
    match viewModel.Form with
    | Failure reason -> reason |> should equal EmailRequired
    | _ -> failwith ""

[<Test>]
let ``registration failed: missing password`` () =

    // Setup
    let viewModel = RegisterViewModel(Dispatcher())
    viewModel.FirstName <- SomeFirstName
    viewModel.LastName  <- SomeLastName
    viewModel.Email     <- match SomeEmail with Email address -> address 
    viewModel.Password  <- ""

    // Test
    viewModel.Register.Execute()

    // Verify
    match viewModel.Form with
    | Failure reason -> reason |> should equal PasswordRequired
    | _ -> failwith ""

[<Test>]
let ``registration failed: missing date of birth`` () =

    // Setup
    let viewModel = RegisterViewModel(Dispatcher())
    viewModel.FirstName   <- SomeFirstName
    viewModel.LastName    <- SomeLastName
    viewModel.Email       <- match SomeEmail with Email address -> address 
    viewModel.Password    <- SomePassword
    viewModel.DateOfBirth <- ""

    // Test
    viewModel.Register.Execute()

    // Verify
    match viewModel.Form with
    | Failure reason -> reason |> should equal DateOfBirthRequired
    | _ -> failwith ""

[<Test>]
let ``registration failed: missing zip code`` () =

    // Setup
    let viewModel = RegisterViewModel(Dispatcher())
    viewModel.FirstName   <- SomeFirstName
    viewModel.LastName    <- SomeLastName
    viewModel.Email       <- match SomeEmail with Email address -> address 
    viewModel.Password    <- SomePassword
    viewModel.DateOfBirth <- SomeDateOfBirth
    viewModel.Zipcode     <- 0

    // Test
    viewModel.Register.Execute()

    // Verify
    match viewModel.Form with
    | Failure reason -> reason |> should equal ZipcodeRequired
    | Success _      -> failwith ""

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
let ``user tries again`` () =

    // Setup
    let viewModel = RegisterViewModel(Dispatcher())

    viewModel.TryAgainConfirmation.Show.Add(fun _ ->
        viewModel.FirstName   <- SomeFirstName
        viewModel.LastName    <- SomeLastName
        viewModel.DateOfBirth <- SomeDateOfBirth 
        viewModel.Email       <- match SomeEmail with Email address -> address   
        viewModel.Password    <- SomePassword  
        viewModel.Zipcode     <- match SomeZipCode with ZipCode zip -> zip
        viewModel.Register.Execute())

    // Test
    viewModel.Register.Execute()

    // Verify
    match viewModel.Form with
    | Success f -> ()
    | Failure r -> failwith ""

[<Test>]
let ``user cancels attempt`` () = 

    // Setup
    let viewModel = RegisterViewModel(Dispatcher())

    viewModel.TryAgainConfirmation.Show.Add(fun _ -> ())

    // Test
    viewModel.Register.Execute()

    // Verify
    match viewModel.Form with
    | Success f -> failwith ""
    | Failure r -> ()