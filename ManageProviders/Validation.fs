module Validation

open ValidationTrack

open FindProviders
open Claims

let validateProviderByName provider =

    let validateName provider =
        match provider.Name with
        | { First=""; Middle=_; Last=_ } -> Failure FirstNameRequired
        | { First=_; Middle=_; Last="" } -> Failure LastNameRequired
        | _ -> Success provider

    let validateOffice (provider:ProviderByName) =
        match provider.Office with Office v -> v |> failOnEmpty provider OfficeRequired

    let validate = validateName >> bind validateOffice
    validate provider

let validateProviderBySpecialty provider =

    let validateSpecialty provider = match provider.Specialty with 
                                     | Specialty v -> v |> failOnEmpty provider SpecialtyRequired

    let validateNetwork provider   = match provider.NetworkName with 
                                     | NetworkName v -> v |> failOnEmpty provider NetworkRequired
                                       
    let validateDistance provider  = match provider.Distance with 
                                     | Distance v -> if v <= 0
                                                     then Failure DistanceRequired
                                                     else Success provider
                                     
    let validateLocation provider = match provider.Location with 
                                    | Location v -> v |> failOnEmpty provider LocationRequired

    let validate = validateSpecialty >> bind validateDistance 
                                     >> bind validateLocation
                                     >> bind validateNetwork
    validate provider