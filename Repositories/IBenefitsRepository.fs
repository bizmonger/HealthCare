namespace Repositories

open Account
open Benefits

type IBenefitsRepository =

    abstract member GetOverview        : PatientId -> BenefitsOverview option
    abstract member GetUsage           : PatientId -> BenefitsUsage    option
    abstract member GetCoverage        : PatientId -> MemberPlan       option
    abstract member GetMemberCoverages : PatientId -> MemberPlan       seq
    abstract member GetMembers         : PatientId -> IdCard           seq
    abstract member GetLastAppointment : PatientId -> Appointment      option
    abstract member GetServices        : CompanyId -> Service          seq