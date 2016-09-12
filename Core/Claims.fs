module Claims

    open Account

    open System
    open Benefits

    type SeviceDescription = SeviceDescription of string
    type ServiceDate =     ServiceDate         of DateTime

    type ServiceDetails = {
        Description:SeviceDescription
        Date:ServiceDate
    }

    type PaymentDetails = PaymentDetails of string

    type Service =  Service  of DateTime * DateTime
    type Office =   Office   of string

    type Provider = {
        Name:Name
        Office:Office
        Network:Network
    }

    type ClaimId = ClaimId of string

    type Claim = {
        ClaimId:ClaimId
        Service:Service
        Provider:Provider
        Office:Office
        Network:Network
    }

    type PaymentSummary = 
        { ClaimId:ClaimId
          ProviderCharged:decimal
          NetworkDiscount:decimal
          InsurancePaid:decimal
        } member this.YourPay() = this.ProviderCharged - this.NetworkDiscount - this.InsurancePaid

    type ProvidersCharged = ProvidersCharged of decimal
    type InsuranceSavings = InsuranceSavings of decimal
    type TotalSavings =     TotalSavings     of int

    type ClaimsSummary = {
        Claims:Claim list
        ProvidersCharged:ProvidersCharged
        InsuranceSavings:InsuranceSavings
        TotalSavings:TotalSavings
    }

    type Specialty = Specialty of string