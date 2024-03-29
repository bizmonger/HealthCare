﻿namespace ManageProviders

open System.Windows.Input
open InteractionLogic
open ValidationTrack

open Repositories
open Account
open Claims
open FindProviders
open Validation

type ProvidersBySpecialtyViewModel(PatientId:PatientId , repository:IProvidersRepository) =

    member val Specialty = "" with get,set
    member val Distance =  0  with get,set
    member val Network =   "" with get,set
    member val Location =  "" with get,set

    member val Specialties = seq [] with get,set
    member val Networks =    seq [] with get,set
    member val Distances =   seq [] with get,set
    member val Providers =   seq [] with get,set

    member val ValidationResult = Failure ProvidersBySpecialtyResponse.NA with get,set

    member this.Load() = 

        this.Specialties <- repository.GetSpecialties()
        this.Networks    <- repository.GetNetworks()
        this.Distances   <- repository.GetDistances()
        
        let searchCriteria = { Specialty=   Specialty   this.Specialty
                               Distance=    Distance    this.Distance
                               Location=    Location    this.Location
                               NetworkName= NetworkName this.Network }

        this.ValidationResult <- validateProviderBySpecialty searchCriteria

        match this.ValidationResult with
        | Success v -> this.Providers <- repository.GetProvidersBySpecialty (Specialty this.Specialty)
        | _ -> this.Providers <- []