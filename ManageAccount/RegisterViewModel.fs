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

    member val PatientId = "" with get,set
    member val Password =  "" with get,set

    member val Form = Failure RegistrationNA with get,set
    member val TryAgainConfirmation = TryAgainConfirmation() :> IConfirmation with get,set

    member this.Register =

        let getName first middle last = 
            if middle = ""
            then { First=first; Middle=None; Last=last }
            else { First=first; Middle=Some middle; Last=last }

        let credentials = credentials this.PatientId this.Password
        let patientId = this.PatientId
        let password = Password this.Password

        let onFormUpdated = function
            | Success form   -> if not (box (dispatcher.RegistrationIsValid) |> isNull)
                                then dispatcher.RegistrationIsValid(this, form)
                                else ()

            | Failure reason -> this.TryAgainConfirmation.Display()

        DelegateCommand( (fun _ -> this.Form <- 
                                    tryRegister { PatientId= PatientId patientId
                                                  Password=  password }

                                   onFormUpdated this.Form),

                          fun _ -> true) :> ICommand