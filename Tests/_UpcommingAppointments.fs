module UpcomingAppointments

open FsUnit
open NUnit.Framework
open Xunit
open TestAPI
open Home
open MockMember

[<Test>]
let ``get upcoming appointments`` () =
    
    // Setup
    let viewModel = UpcomingAppointmentsViewModel(SomePatientId, MockProfileRepository())

    // Test
    viewModel.Load()

    // Verify
    viewModel.Appointments.Length |> should be (greaterThan 0)