namespace Repositories

open Account
open System

type IProfileRepository =

    abstract member GetProfile      : PatientId -> Profile option
    abstract member GetDependents   : PatientId -> Profile list
    abstract member GetLastCleaning : PatientId -> DateTime option
    abstract member GetLastVisit    : PatientId -> DateTime option
    abstract member GetAppointments : PatientId -> DateTime list
    abstract member Save            : Profile   -> unit