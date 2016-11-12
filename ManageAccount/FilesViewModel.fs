namespace ManageAccount

open InteractionLogic
open Account
open Repositories
open System.Windows.Input

type FilesViewModel(patientId:PatientId , dispatcher:Dispatcher , repository:IProfileRepository) =

    
    member val Files =             [] with get,set
    member val File:File option  = None with get,set

    member this.GetFile() =        dispatcher.SelectFile()
    member this.Save()    =        ()

    member this.Load =
        
        DelegateCommand( (fun _ -> this.Files <- repository.GetFiles patientId) , 
                          fun _ -> true ) :> ICommand