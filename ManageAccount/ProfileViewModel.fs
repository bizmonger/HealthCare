namespace ManageAccount

open System.Windows.Input
open InteractionLogic
open Account
open Repositories

type ProfileViewModel(patientId:PatientId , dispatcher:Dispatcher , repository:IProfileRepository) =

    member val Profile:Profile    option = None with get,set
    member val Dependent:Profile  option = None with get,set
    member val Dependents:Profile list =   [] with get,set

    member this.Load() =
        this.Profile    <- repository.GetProfile    patientId
        this.Dependents <- repository.GetDependents patientId

    member this.ViewDependent =

        DelegateCommand ( (fun _ -> match this.Dependent with
                                    | Some v -> dispatcher.ViewProfile v.IdCard.PatientId
                                    | None   -> () ) , 
                           fun _ -> this.Dependent.IsSome) :> ICommand