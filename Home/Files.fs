namespace Home

open Account

type FilesViewModel(patientId:PatientId) =

    member val Files = [] with get,set
    member val File  = None with get,set

    member this.GetFile() = ()
    member this.Save()    = ()