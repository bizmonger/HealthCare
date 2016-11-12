namespace ManageAccount

open InteractionLogic
open Account
open Repositories
open System.Windows.Input

type FilesViewModel(patientId:PatientId , dispatcher:Dispatcher , repository:IProfileRepository) =

    
    member val Files = [] with get,set
    member val File  = None with get,set

    member this.Load() =
        this.Files <- repository.GetFiles patientId

    member this.OnFileSelected (file:File) =
        this.File  <- Some file

    member this.GetFile() = dispatcher.SelectFile()
    member this.Save() = ()