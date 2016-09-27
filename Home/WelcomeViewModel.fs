namespace Home

open Repositories
open Account
open System

type WelcomeViewModel(memberId:MemberId , repository:IProfileRepository) =

    member val Profile =      None with get,set
    member val LastCleaning = None with get,set
    member val LastVisit =    None with get,set

    member this.Load() =

        this.Profile      <- repository.GetProfile      memberId
        this.LastCleaning <- repository.GetLastCleaning memberId
        this.LastVisit    <- repository.GetLastVisit    memberId