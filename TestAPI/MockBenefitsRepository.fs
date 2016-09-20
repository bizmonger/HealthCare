namespace TestAPI

open Repositories
open MockOverview
open MockMember

type MockBenefitsRepository() =
    
    interface IBenefitsRepository with
        member this.GetOverview        memberId = anonymousOverview
        member this.GetUsage           memberId = anonymousUsage
        member this.GetCoverage        memberId = Some anonymousCoverage
        member this.GetMemberCoverages memberId = seq [anonymousCoverage]
        member this.GetMembers         memberId = SomeMembers
        member this.GetLastAppointment memberId = Some SomeAppointment