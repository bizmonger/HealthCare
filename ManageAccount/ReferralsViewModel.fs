namespace ManageAccount

open InteractionLogic
open Account
open Repositories
open Contact
open System.Windows.Input

type ReferalsViewModel(patientId:PatientId , repository:IReferralsRepository) =
    
    member val ReferralAddress = "" with get,set

    member this.Submit =
        let email = Email this.ReferralAddress
        DelegateCommand( (fun _ -> repository.SubmitReferral patientId email) , 
                          fun _ -> this.ReferralAddress <> "" ) :> ICommand