namespace TestAPI

open Repositories
open MockMember

type MockBenefitsRepository() =
    
    interface IBenefitsRepository with
        member this.GetOverview        patientId = Some anonymousOverview
        member this.GetUsage           patientId = Some anonymousUsage
        member this.GetCoverage        patientId = Some anonymousCoverage
        member this.GetMemberCoverages patientId = SomeMemberCoverages
        member this.GetMembers         patientId = SomeMembers
        member this.GetServices        companyId = SomeServices
        member this.GetLastAppointment patientId = Some SomeAppointment
