namespace ManageAccount

open InteractionLogic
open Repositories
open Account

type DependentProfilesViewModel( PatientId:PatientId , dispatcher:Dispatcher , repository:IProfileRepository) =

    member val Dependents = seq [] with get,set

    member this.Load() =
        this.Dependents <- repository.GetDependents PatientId

    member this.OnProfileSelected (profile:Profile) =
        dispatcher.ViewProfile profile.IdCard.PatientId