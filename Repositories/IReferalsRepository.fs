namespace Repositories

open Account
open Contact

type IReferalsRepository =

    abstract member SubmitReferral : PatientId -> Email -> unit