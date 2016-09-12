module  SearchProviderResults

open FsUnit
open NUnit.Framework

open InteractionLogic
open ManageProviders

[<Test>]
let ``show options for search result`` () = 
    
    // Setup
    let viewModel = ProvidersViewModel(Dispatcher())

    // Test
    viewModel.ViewOptions.Execute()

    // Verify
    viewModel.HideOptions |> should equal false

[<Test>]
let ``save search result as contact`` () =

    // Setup
    let mutable addContactRequested = false
    let dispatcher = Dispatcher()
    dispatcher.AddContactRequested.Add(fun _ -> addContactRequested <- true)
    let viewModel = ProvidersViewModel(dispatcher)

    // Test
    viewModel.AddAsContact.Execute()

    // Verify
    addContactRequested |> should equal true

[<Test>]
let ``share search result via email`` () = 

    // Setup
    let mutable shareResultsRequested = false
    let dispatcher = Dispatcher()
    dispatcher.EmailProvidersRequested.Add(fun _ -> shareResultsRequested <- true)
    let viewModel = ProvidersViewModel(dispatcher)

    // Test
    viewModel.EmailProviders.Execute()

    // Verify
    shareResultsRequested |> should equal true

[<Test>]
let ``share search result via text msg`` () = 

    // Setup
    let mutable shareResultsRequested = false
    let dispatcher = Dispatcher()
    dispatcher.TextMessageProvidersRequested.Add(fun _ -> shareResultsRequested <- true)
    let viewModel = ProvidersViewModel(dispatcher)

    // Test
    viewModel.TextMessageProviders.Execute()

    // Verify
    shareResultsRequested |> should equal true