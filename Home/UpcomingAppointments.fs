namespace Home

open Account
open Repositories

type UpcomingAppointmentsViewModel(patientId:PatientId , repository:IProfileRepository) =

    member val Appointments = [] with get,set

    member this.Load() =
        this.Appointments <- repository.GetAppointments(patientId)