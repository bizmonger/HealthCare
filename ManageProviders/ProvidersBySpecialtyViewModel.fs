namespace ManageProviders

open System.Windows.Input
open InteractionLogic
open ValidationTrack

open Repositories
open Account
open Claims
open Benefits
open FindProviders

type ProvidersBySpecialtyViewModel(memberId:MemberId , repository:IProvidersRepository) =

    member val Specialty = ""   with get,set
    member val Distance =  ""   with get,set
    member val Network =   ""   with get,set
    member val Location =  ""   with get,set
    member val Providers = []   with get,set

    member val ValidationResult = ProvidersBySpecialtyResponse.NA with get

    member this.LoadProviders =
        DelegateCommand ( (fun _ -> this.Providers <- repository.GetProvidersBySpecialty (Specialty this.Specialty) ) , 
                           fun _ -> true ) :> ICommand