module  Home
 
open FsUnit
open NUnit.Framework

open InteractionLogic

open Home
open Account
open SignIn
open MockSignIn
open MockMember

[<Test>]
let ``navigate to viewIdCard after signing in`` () =

    // Setup
    let mutable idCardRequested = false
    let dispatcher = Dispatcher()
    dispatcher.IdRequested.Add(fun _ -> idCardRequested <- true)

    let homeViewModel = HomeViewModel(dispatcher)

    signIn { PatientId= SomePatientId
             Password= Password SomePassword } 
             dispatcher

    // Test
    homeViewModel.TryViewIdCard.Execute()

    // Verify
    idCardRequested |> should equal true

[<Test>]
let ``cannot navigate to viewIdCard if not signed in`` () =

    // Setup
    let mutable idCardRequested = false;
    let dispatcher = Dispatcher()
    dispatcher.IdRequested.Add(fun _ -> idCardRequested <- true)
    let viewModel = HomeViewModel(dispatcher)

    // Test
    viewModel.TryViewIdCard.Execute()

    // Verify
    idCardRequested |> should equal false

[<Test>]
let ``cannot navigate to viewIdCard if disabled as feature`` () = 

    // Setup
    let mutable idCardRequested = false;
    let dispatcher = Dispatcher()
    dispatcher.IdRequested.Add(fun _ -> idCardRequested <- true)
    let viewModel = HomeViewModel(dispatcher)

    // Test
    viewModel.TryViewIdCard.Execute()

    // Verify
    idCardRequested |> should equal false

[<Test>]
let ``navigate to viewIdCard after enabling feature`` () =

    // Setup
    let mutable idCardRequested = false;
    let dispatcher = Dispatcher()
    dispatcher.IdRequested.Add(fun _ -> idCardRequested <- true)
    let viewModel = HomeViewModel(dispatcher)
    viewModel.Settings <- { ViewIdCardFromHome=true }

    // Test
    viewModel.TryViewIdCard.Execute()

    // Verify
    idCardRequested |> should equal true

[<Test>]
let ``navigate to findProvider`` () =

    // Setup
    let mutable providersRequested = false;
    
    let dispatcher = Dispatcher()
    dispatcher.FindProvidersRequested.Add(fun _ -> providersRequested <- true)
    let viewModel = HomeViewModel(dispatcher)

    // Test
    viewModel.FindProviders.Execute()

    // Verify
    providersRequested |> should equal true

[<Test>]
let ``navigate to signin`` () =

    // Setup
    let mutable signinRequested = false;
    
    let dispatcher = Dispatcher()
    dispatcher.SignInRequested.Add(fun _ -> signinRequested <- true)
    let viewModel = HomeViewModel(dispatcher)

    // Test
    viewModel.SignIn.Execute()

    // Verify
    signinRequested |> should equal true

[<Test>]
let ``navigate to register`` () =

    // Setup
    let mutable registerRequested = false;
    
    let dispatcher = Dispatcher()
    dispatcher.RegistrationRequested.Add(fun _ -> registerRequested <- true)
    let viewModel = HomeViewModel(dispatcher)

    // Test
    viewModel.Register.Execute()

    // Verify
    registerRequested |> should equal true

[<Test>]
let ``navigate to contact`` () =
    
    // Setup
    let mutable contactRequested = false;
    let dispatcher = Dispatcher()
    dispatcher.ContactRequested.Add(fun _ -> contactRequested <- true)
    let viewModel = HomeViewModel(dispatcher)
    
    // Test
    viewModel.ViewContact.Execute()

    // Verify
    contactRequested |> should equal true

[<Test>]
let ``navigate to tips`` () =

    // Setup
    let mutable tipsRequested = false;
    let dispatcher = Dispatcher()
    dispatcher.TipsRequested.Add(fun _ -> tipsRequested <- true)
    let viewModel = HomeViewModel(dispatcher)
    
    // Test
    viewModel.ViewTips.Execute()

    // Verify
    tipsRequested |> should equal true

[<Test>]
let ``navigate to FAQ`` () =

    // Setup
    let mutable faqRequested = false;
    let dispatcher = Dispatcher()
    dispatcher.FAQRequested.Add(fun _ -> faqRequested <- true)
    let viewModel = HomeViewModel(dispatcher)
    
    // Test
    viewModel.ViewFAQ.Execute()

    // Verify
    faqRequested |> should equal true

[<Test>]
let ``navigate to privacy`` () =

    // Setup
    let mutable privacyRequested = false;
    let dispatcher = Dispatcher()
    dispatcher.PrivacyRequested.Add(fun _ -> privacyRequested <- true)
    let viewModel = HomeViewModel(dispatcher)

    // Test
    viewModel.ViewPrivacy.Execute()

    // Verify
    privacyRequested |> should equal true

[<Test>]
let ``navigate to info`` () =

    // Setup
    let mutable infoRequested = false;
    
    let dispatcher = Dispatcher()
    dispatcher.InfoRequested.Add(fun _ -> infoRequested <- true)
    let viewModel = HomeViewModel(dispatcher)

    // Test
    viewModel.ViewInfo.Execute()

    // Verify
    infoRequested |> should equal true