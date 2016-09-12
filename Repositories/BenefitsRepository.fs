namespace Repositories

type BenefitsRepository() =

    interface IBenefitsRepository with
        member this.GetOverview        memberId = failwith "BenefitsRepository not implemented"
        member this.GetUsage           memberId = failwith "BenefitsRepository not implemented"
        member this.GetCoverage        memberId = failwith "BenefitsRepository not implemented"
        member this.GetMembers         memberId = failwith "BenefitsRepository not implemented"
        member this.GetLastAppointment memberId = failwith "BenefitsRepository not implemented"