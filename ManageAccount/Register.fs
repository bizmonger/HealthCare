module Register

open ValidationTrack
open SignIn
open Account
open System.Diagnostics

(* Types *)
type Form = { 
    Name:Name
    Email:Email
    Password:Password
    DateOfBirth:DateOfBirth
    ZipCode:ZipCode
}

type RegisterResponse =
    | RegistrationNA
    | FirstNameRequired
    | LastNameRequired
    | EmailRequired
    | DateOfBirthRequired
    | ZipcodeRequired
    | PasswordRequired
    | RegistrationSucceeded

(* Functions *)
let tryRegister form =

    let validateName form =
        match form.Name with
        | { First=""; Middle=_; Last=_ } -> Failure FirstNameRequired
        | { First=_; Middle=_; Last="" } -> Failure LastNameRequired
        | _ -> Success form

    let validateEmail form =
        match form.Email with Email address         -> address |> failOnEmpty form EmailRequired

    let validatePassword form =
        match form.Password with Password pwd       -> pwd     |> failOnEmpty form PasswordRequired

    let validateDOB form =
        match form.DateOfBirth with DateOfBirth dob -> dob     |> failOnEmpty form DateOfBirthRequired

    let validateZip (form:Form) =
        match form.ZipCode with ZipCode code        -> if code = 0 
                                                       then Failure ZipcodeRequired 
                                                       else code.ToString() |> failOnEmpty form ZipcodeRequired
    let validate = validateName >> bind validateEmail 
                                >> bind validatePassword 
                                >> bind validateDOB 
                                >> bind validateZip
    validate form