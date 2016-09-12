namespace TestAPI

open MockMember
open Repositories
open Account

type MockProfileRepository() =

    let mutable profile = SomeProfile

    interface IProfileRepository with
        member this.GetProfile    memberId =       Some profile
        member this.GetDependents memberId =       [SomeProfile]
        member this.Save          editedProfile  = profile <- editedProfile