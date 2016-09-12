module Validation

open ValidationTrack
open FindProviders
open Claims

let validate (provider:Provider) =

    let validateName (provider:Provider) =
        match provider.Name with
        | { First=""; Middle=_; Last=_ } -> Failure FirstNameRequired
        | { First=_; Middle=_; Last="" } -> Failure LastNameRequired
        | _ -> Success provider

    let validateOffice (provider:Provider) =
        match provider.Office with Office v -> v |> failOnEmpty provider OfficeRequired

    let validate =

        let validateOffice' =  bind validateOffice

        validateName >> validateOffice'

    validate provider



