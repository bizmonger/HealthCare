namespace ManageAccount

open InteractionLogic
open Account
open Repositories
open System.Windows.Input

type FilesViewModel(patientId:PatientId , repository:IProfileRepository) =
    
    member val Files = [] with get,set

    member this.Load =
        
        DelegateCommand( (fun _ -> this.Files <- repository.GetFiles patientId) , 
                          fun _ -> true ) :> ICommand