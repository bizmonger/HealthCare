module ChangePassword

open FsUnit
open Xunit
open NUnit.Framework
open TestAPI
open Account
open ManageAccount
open MockMember

[<Test>]
let ``cannot change password if old and new are different`` () =
    
    // Setup
    let viewModel = ChangePasswordViewModel(MockProfileRepository())

    viewModel.Password        <- SomePassword
    viewModel.ConfirmPassword <- SomePassword + "edited"

    // Verify
    viewModel.Save.CanExecute() |> should equal false