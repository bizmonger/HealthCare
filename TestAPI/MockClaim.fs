﻿module MockClaim

open System
open Claims
open MockMember
open Benefits

let SomeClaimId = ClaimId "some_claim_id"
let SomeOffice =  Office  "some_office"

let SomeNetwork = { PreventiveAndDiagnostic= PreventiveAndDiagnostic 0
                    Restoration=             Restoration 0
                    OralSurgery=             OralSurgery 0
                    Periodontics=            Periodontics 0 }

let anonymousClaim = {
    ClaimId = SomeClaimId
    Service=Service (DateTime.Now , DateTime.Now.AddMonths(1))
    Provider={Name=SomeName ; Office= SomeOffice; Network=SomeNetwork}
    Office=SomeOffice
    Network= inNetwork
}

let mockPaymentSummary = { 
    ClaimId=SomeClaimId
    ProviderCharged=100m
    NetworkDiscount=10m
    InsurancePaid=20m
}

let anonymousPaymentDetails = PaymentDetails "some_payment_details"
let anonymousServiceDetails = { Description= SeviceDescription "some_service_details"
                                Date= ServiceDate DateTime.Now }

let SomeClaims = [anonymousClaim]

let SomeProvidersCharged =  ProvidersCharged 50m
let SomeInsuranceSavings =  InsuranceSavings 50m

let SomeFamilyClaimsSummary = {
    Member = SomeIdCard
    Claims = SomeClaims
    ProvidersCharged = SomeProvidersCharged
    InsuranceSavings = SomeInsuranceSavings
}

let SomeDependentSummaries = seq [SomeFamilyClaimsSummary]

let anonymousFamilySummary = {
    Member = SomeIdCard
    Claims=SomeClaims
    ProvidersCharged=SomeProvidersCharged
    InsuranceSavings=SomeInsuranceSavings }

let anonymousMemberSummaries = seq [anonymousFamilySummary ; anonymousFamilySummary ; anonymousFamilySummary]

let SomeProvider = {
    Name=SomeName
    Office=SomeOffice
    Network=SomeNetwork
}

let SomeProviders =   seq [SomeProvider]
let SomeSpecialties = seq ["specialty_1" ; "specialty_2" ; "specialty_3"]
let SomeNetworks =    seq ["network1" ; "network2" ; "network3"]
let SomeDistances =   seq [5 ; 10 ; 25; 50]