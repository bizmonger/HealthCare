﻿module MockClaim

open System
open Claims
open MockMember
open Benefits

let SomeClaimId =     ClaimId     "some_claim_id"
let SomeOffice =      Office      "some_office"
let SomeServiceName = ServiceName "some_service_name"

let SomeNetwork = { PreventiveAndDiagnostic= PreventiveAndDiagnostic 0
                    Restoration=             Restoration 0
                    OralSurgery=             OralSurgery 0
                    Periodontics=            Periodontics 0 }

let SomeClaim = {

    ClaimId = SomeClaimId

    Service=  { Name=SomeServiceName
                FromDate=DateTime.Now
                ToDate=DateTime.Now.AddMonths(1) }

    Provider= { Name=SomeName
                Office= SomeOffice
                Network=SomeNetwork }

    Office=SomeOffice
    Network= inNetwork
}

let SomePaymentSummary = { 
    ClaimId=SomeClaimId
    ProviderCharged=100m
    NetworkDiscount=10m
    InsurancePaid=20m
}

let anonymousPaymentDetails = { ClaimId=SomeClaimId ; Paid=100.00m }
let anonymousServiceDetails = { Description= SeviceDescription "some_service_details"
                                Date= ServiceDate DateTime.Now }

let SomeClaims = [SomeClaim]

let SomeProvidersCharged =  ProvidersCharged 50m
let SomeInsuranceSavings =  InsuranceSavings 50m

let SomeFamilySummary = {
    Member = SomeIdCard
    Claims=SomeClaims
    ProvidersCharged=SomeProvidersCharged
    InsuranceSavings=SomeInsuranceSavings }

let SomeClaimsSummary = {
    Member = SomeIdCard
    Claims=SomeClaims
    ProvidersCharged=SomeProvidersCharged
    InsuranceSavings=SomeInsuranceSavings }

let SomeDependentSummaries = seq [SomeFamilySummary ; SomeFamilySummary ; SomeFamilySummary]

let SomeProvider = {
    Name=SomeName
    Office=SomeOffice
    Network=SomeNetwork
}

let SomeProviders =   seq [SomeProvider]
let SomeSpecialties = seq ["specialty_1" ; "specialty_2" ; "specialty_3"]
let SomeNetworks =    seq ["network1" ; "network2" ; "network3"]
let SomeDistances =   seq [5 ; 10 ; 25; 50]