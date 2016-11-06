namespace Home

open InteractionLogic
open Account

type FilesViewModel(patientId:PatientId , dispatcher:Dispatcher) as this =

    do dispatcher.FileSelected.Add (fun file -> this.File <- Some file)

    member val Files = []   with get,set
    member val File  = None with get,set

    member this.GetFile() = dispatcher.SelectFile()

    member this.Save()    = ()