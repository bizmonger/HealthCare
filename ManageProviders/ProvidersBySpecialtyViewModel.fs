﻿namespace ManageProviders

open System.Windows.Input
open InteractionLogic
open ValidationTrack

open Repositories
open Account
open Claims
open Benefits
open FindProviders
open Validation

type ProvidersBySpecialtyViewModel(memberId:MemberId , repository:IProvidersRepository) =

    member val Specialty = ""   with get,set
    member val Distance =  0    with get,set
    member val Network =   ""   with get,set
    member val Location =  ""   with get,set
    member val Providers = []   with get,set

    member val ValidationResult = Failure ProvidersBySpecialtyResponse.NA with get,set

    member this.LoadProviders =
        
        let searchCriteria = { Specialty=   Specialty this.Specialty
                               Distance=    Distance  this.Distance
                               Location=    Location  this.Location
                               NetworkName= NetworkName this.Network }

        this.ValidationResult <- validateProviderBySpecialty searchCriteria

        DelegateCommand ( (fun _ -> match this.ValidationResult with
                                    | Success v -> this.Providers <- repository.GetProvidersBySpecialty (Specialty this.Specialty)
                                    | _ -> this.Providers <- [] ) ,
                           fun _ -> true ) :> ICommand