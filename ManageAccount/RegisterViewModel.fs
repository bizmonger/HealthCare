namespace ManageAccount

open System.Windows.Input

open InteractionLogic
open ValidationTrack
open Account
open Register
open SignIn
open Confirmation
open Contact

type RegisterViewModel(dispatcher:Dispatcher) =

    let registrationSucceeded = new Event<_>()

    [<CLIEvent>]
    member this.RegisterSucceeded = registrationSucceeded.Publish

    member val FirstName =   "" with get,set
    member val MiddleName =  "" with get,set
    member val LastName =    "" with get,set
    member val Email =       "" with get,set
    member val UserName =    "" with get,set
    member val Password =    "" with get,set
    member val Zipcode =     0 with get,set
    member val DateOfBirth = "" with get,set

    member val Form = Failure RegistrationNA with get,set
    member val TryAgainConfirmation = TryAgainConfirmation() :> IConfirmation with get,set

    member this.Register =

        let getName first middle last = 
            if middle = ""
            then { First=first; Middle=None; Last=last }
            else { First=first; Middle=Some middle; Last=last }

        let name = getName this.FirstName this.MiddleName this.LastName
        let credentials = credentials this.UserName this.Password
        let PatientId = this.Email
        let password = Password this.Password
        let dob = DateOfBirth this.DateOfBirth
        let zip = this.Zipcode

        let onFormUpdated = function
            | Success form   -> if not (box (dispatcher.RegistrationIsValid) |> isNull)
                                then dispatcher.RegistrationIsValid(this, form)
                                else ()

            | Failure reason -> this.TryAgainConfirmation.Display()

        DelegateCommand( (fun _ -> this.Form <- 
                                    tryRegister { Name=        name
                                                  Email=       Email PatientId
                                                  Password=    password
                                                  DateOfBirth= dob
                                                  ZipCode=     ZipCode zip }

                                   onFormUpdated this.Form),

                          fun _ -> true) :> ICommand