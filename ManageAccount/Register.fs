module Register

open System.Diagnostics
open ValidationTrack
open SignIn
open Account
open Contact

(* Types *)
type Form = { 
    PatientId:PatientId
    Password:Password
}

type RegisterResponse =
    | RegistrationNA
    | PatientIdRequired
    | PasswordRequired
    | RegistrationSucceeded

(* Functions *)
let tryRegister form =

    let validatePatientId form =
        match form.PatientId with PatientId patientId -> patientId |> failOnEmpty form PatientIdRequired

    let validatePassword form =
        match form.Password with Password pwd        -> pwd       |> failOnEmpty form PasswordRequired

    let validate = validatePatientId >> bind validatePassword 
    validate form