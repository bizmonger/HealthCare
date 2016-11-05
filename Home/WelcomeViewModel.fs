namespace Home

open Repositories
open Account
open System

type WelcomeViewModel(patientId:PatientId , repository:IProfileRepository) =

    member val Profile =      None with get,set
    member val LastCleaning = None with get,set
    member val LastVisit =    None with get,set

    member this.Load() =

        this.Profile      <- repository.GetProfile      patientId
        this.LastCleaning <- repository.GetLastCleaning patientId
        this.LastVisit    <- repository.GetLastVisit    patientId