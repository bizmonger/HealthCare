namespace Repositories

open Account
open System
open Contact

type IProfileRepository =

    abstract member GetProfile        : PatientId          -> Profile  option
    abstract member GetDependents     : PatientId          -> Profile  list
    abstract member GetLastCleaning   : PatientId          -> DateTime option
    abstract member GetLastVisit      : PatientId          -> DateTime option
    abstract member GetAppointments   : PatientId          -> DateTime list
    abstract member GetFiles          : PatientId          -> File     list
    abstract member Save              : Profile            -> unit
    abstract member TryChangePassword : PasswordChange     -> unit