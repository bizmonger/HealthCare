module Files

open FsUnit
open NUnit.Framework
open Xunit
open MockMember
open Home

[<Test>]
let ``add file`` () =

    // Setup
    let mutable fileSaved = false
    let viewModel = FilesViewModel(SomePatientId)
    viewModel.GetFile()

    // Test
    viewModel.Save()

    // Verify
    fileSaved |> should equal true
