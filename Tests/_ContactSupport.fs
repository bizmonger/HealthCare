module  ContactSupport

open FsUnit
open NUnit.Framework
open MockMember
open MockClaim
open TestAPI

open InteractionLogic
open GetSupport
    
[<Test>]
let ``load last service summary`` () =

    // Setup
    let viewModel = SupportViewModel(SomeMemberId , Dispatcher() , MockClaimsRepository())

    // Test
    viewModel.LoadLastService.Execute()

    // Verify
    match viewModel.LastService with
    | Some service -> service |> should equal anonymousServiceDetails
    | None -> failwith ""

[<Test>]
let ``call`` () =
    
    // Setup
    let mutable callRequested = false
    let dispatcher = Dispatcher()
    dispatcher.CallSupportRequested.Add (fun _ -> callRequested <- true)
    let viewModel = SupportViewModel(SomeMemberId , dispatcher , MockClaimsRepository())

    // Test
    viewModel.CallSupport.Execute()

    // Verify
    callRequested |> should equal true

[<Test>]
let ``email`` () =
    
    // Setup
    let mutable emailRequested = false
    let dispatcher = Dispatcher()
    dispatcher.EmailSupportRequested.Add (fun _ -> emailRequested <- true)
    let viewModel = SupportViewModel(SomeMemberId , dispatcher , MockClaimsRepository())

    // Test
    viewModel.EmailSupport.Execute()

    // Verify
    emailRequested |> should equal true