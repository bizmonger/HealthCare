namespace Repositories

open Account
open Benefits

type IBenefitsRepository =

    abstract member GetOverview        : MemberId -> BenefitsOverview option
    abstract member GetUsage           : MemberId -> BenefitsUsage    option
    abstract member GetCoverage        : MemberId -> MemberPlan       option
    abstract member GetMemberCoverages : MemberId -> MemberPlan       seq
    abstract member GetMembers         : MemberId -> IdCard           seq
    abstract member GetLastAppointment : MemberId -> Appointment      option