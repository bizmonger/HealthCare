namespace Repositories

open Account
open Claims

type IClaimsRepository =

    abstract member GetFamilySummary      : PatientId -> ClaimsSummary option
    abstract member GetDependentSummaries : PatientId -> ClaimsSummary seq
    abstract member GetSummary            : PatientId -> ClaimsSummary option
    abstract member GetDetails            : ClaimId  -> Claim option
    abstract member GetPaymentSummary     : ClaimId  -> PaymentOwedSummary option
    abstract member GetPaymentDetails     : ClaimId  -> PaymentDetails option
    abstract member GetServiceDetails     : ClaimId  -> ServiceDetails option
    abstract member GetLastService        : PatientId -> ServiceDetails option