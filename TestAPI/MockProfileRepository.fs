namespace TestAPI

open MockMember
open Repositories
open Account
open System

type MockProfileRepository() =

    let mutable profile = SomeProfile

    interface IProfileRepository with
        member this.GetProfile      memberId       = Some profile
        member this.GetDependents   memberId       = [SomeProfile ; SomeProfile ; SomeProfile]
        member this.GetLastCleaning memberId       = Some DateTime.Now
        member this.GetLastVisit    memberId       = Some DateTime.Now
        member this.Save            editedProfile  = profile <- editedProfile