[<System.Diagnostics.DebuggerNonUserCode>]
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

    type ProviderByName = {
        Name:Name
        Office:Office
        Network:Network
    }

    type NetworkName = NetworkName of string

    type Specialty = Specialty of string
    type Distance =  Distance  of int
    type Location =  Location  of string

    type ProviderBySpecialty = {
        Specialty:Specialty
        Distance:Distance
        Location:Location
        NetworkName:NetworkName
    }

    type ClaimId = ClaimId of string

    type Claim = {
        ClaimId:ClaimId
        Service:Service
        Provider:ProviderByName
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