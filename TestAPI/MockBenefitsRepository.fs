namespace TestAPI

open Repositories
open MockMember

type MockBenefitsRepository() =
    
    interface IBenefitsRepository with
        member this.GetOverview        PatientId = Some anonymousOverview
        member this.GetUsage           PatientId = Some anonymousUsage
        member this.GetCoverage        PatientId = Some anonymousCoverage
        member this.GetMemberCoverages PatientId = SomeMemberCoverages
        member this.GetMembers         PatientId = SomeMembers
        member this.GetLastAppointment PatientId = Some SomeAppointment
