namespace ManageAccount

open Repositories
open Account

type DependentProfilesViewModel(repository:IProfileRepository , memberId:MemberId) =

    member val Dependents = seq [] with get,set

    member this.Load() =
        this.Dependents <- repository.GetDependents memberId