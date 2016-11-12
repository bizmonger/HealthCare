module Files

open FsUnit
open NUnit.Framework
open Xunit
open TestAPI
open MockMember
open ManageAccount
open InteractionLogic

[<Test>]
let ``get file`` () =

    // Setup
    let mutable file = None
    let dispatcher = Dispatcher()
    let viewModel = FilesViewModel(SomePatientId , dispatcher, MockProfileRepository())

    dispatcher.FileSelected.Add (fun _ -> viewModel.File <- Some SomeFile)

    // Test
    viewModel.GetFile()

    // Verify
    match viewModel.File with
    | None   -> failwith ""
    | Some _ -> ()

[<Test>]
let ``load files`` () =
    
    // Setup
    let viewModel = FilesViewModel(SomePatientId , Dispatcher(), MockProfileRepository())

    // Test
    viewModel.Load()

    // Verify
    viewModel.Files |> should equal [SomeFile]