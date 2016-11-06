module Files

open FsUnit
open NUnit.Framework
open Xunit
open MockMember
open Home

open InteractionLogic

[<Test>]
let ``get file`` () =

    // Setup
    let mutable fileRetrieved = false
    let dispatcher = Dispatcher()
    dispatcher.FileSelected.Add (fun _ -> fileRetrieved <- true)

    let viewModel = FilesViewModel(SomePatientId , dispatcher)

    // Test
    viewModel.GetFile()

    // Verify
    match viewModel.File with
    | None   -> failwith ""
    | Some _ -> ()