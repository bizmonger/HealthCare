namespace TestAPI

open Repositories
open MockMember

type MockBenefitsRepository() =
    
    interface IBenefitsRepository with
        member this.GetOverview        memberId = Some anonymousOverview
        member this.GetUsage           memberId = Some anonymousUsage
        member this.GetCoverage        memberId = Some anonymousCoverage
        member this.GetMemberCoverages memberId = SomeMemberCoverages
        member this.GetMembers         memberId = SomeMembers
        member this.GetLastAppointment memberId = Some SomeAppointment