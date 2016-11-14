namespace ManageClaims

open Account
open Repositories

type UpcomingAppointmentsViewModel(patientId:PatientId , repository:IClaimsRepository) =

    member val Appointments = [] with get,set
    member this.Load() =
        repository.GetUpcomingAppointments patientId