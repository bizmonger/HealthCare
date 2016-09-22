[<System.Diagnostics.DebuggerNonUserCode>]
module Claims

    open System
    open Account
    open Benefits

    type ClaimId = ClaimId of string

    type PaymentDetails = {
        ClaimId:ClaimId
        Paid:decimal
    }

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

    type Claim = {
        ClaimId:ClaimId
        Service:Service
        Provider:ProviderByName
        Office:Office
        Network:Network
    }

    type PaymentOwedSummary = 
        { ClaimId:ClaimId
          ProviderCharged:decimal
          NetworkDiscount:decimal
          InsurancePaid:decimal
        } member this.YourPay() = this.ProviderCharged - this.NetworkDiscount - this.InsurancePaid

    type ProvidersCharged = ProvidersCharged of decimal
    type InsuranceSavings = InsuranceSavings of decimal

    type ClaimsSummary = 
        { Member:IdCard
          Claims:Claim seq
          ProvidersCharged:ProvidersCharged
          InsuranceSavings:InsuranceSavings 
        } member this.TotalSavings() =
            let (ProvidersCharged charged) = this.ProvidersCharged
            let (InsuranceSavings savings) = this.InsuranceSavings
            charged - savings

    type SeviceDescription = SeviceDescription of string
    type ServiceDate =       ServiceDate       of DateTime

    type ServiceDetails = {
        Description:SeviceDescription
        Date:ServiceDate
    }