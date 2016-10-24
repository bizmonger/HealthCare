namespace Home

open Repositories
open Account
open System

type WelcomeViewModel(PatientId:PatientId , repository:IProfileRepository) =

    member val Profile =      None with get,set
    member val LastCleaning = None with get,set
    member val LastVisit =    None with get,set

    member this.Load() =

        this.Profile      <- repository.GetProfile      PatientId
        this.LastCleaning <- repository.GetLastCleaning PatientId
        this.LastVisit    <- repository.GetLastVisit    PatientId