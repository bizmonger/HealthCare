namespace ManageAccount

open InteractionLogic
open Repositories
open Account

type DependentProfilesViewModel( memberId:MemberId , dispatcher:Dispatcher , repository:IProfileRepository) =

    member val Dependents = seq [] with get,set

    member this.Load() =
        this.Dependents <- repository.GetDependents memberId

    member this.OnProfileSelected (profile:Profile) =
        dispatcher.ViewProfile profile.IdCard.MemberId