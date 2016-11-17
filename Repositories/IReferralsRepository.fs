namespace Repositories

open Account
open Contact

type IReferralsRepository =

    abstract member SubmitReferral : PatientId -> Email -> unit