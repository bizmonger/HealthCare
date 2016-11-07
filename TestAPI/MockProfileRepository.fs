namespace TestAPI

open MockMember
open Repositories
open Account
open System

type MockProfileRepository() =

    let mutable profile = SomeProfile

    interface IProfileRepository with       

        member this.GetProfile        patientId     = Some profile
        member this.GetDependents     patientId     = [SomeProfile ; SomeProfile ; SomeProfile]
        member this.GetLastCleaning   patientId     = Some DateTime.Now
        member this.GetLastVisit      patientId     = Some DateTime.Now
        member this.GetAppointments   patientId     = [DateTime.Now]
        member this.TryChangePassword change        = ()
        member this.Save              editedProfile = profile <- editedProfile