namespace Repositories

open Account
open Claims

type IClaimsRepository =

    abstract member GetFamilySummary      : MemberId -> ClaimsSummary option
    abstract member GetDependentSummaries : MemberId -> ClaimsSummary seq
    abstract member GetSummary            : MemberId -> ClaimsSummary option
    abstract member GetDetails            : ClaimId  -> Claim option
    abstract member GetPaymentSummary     : ClaimId  -> PaymentOwedSummary option
    abstract member GetPaymentDetails     : ClaimId  -> PaymentDetails option
    abstract member GetServiceDetails     : ClaimId  -> ServiceDetails option
    abstract member GetLastService        : MemberId -> ServiceDetails option