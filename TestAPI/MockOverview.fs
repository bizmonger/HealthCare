module MockOverview

open Account
open Benefits
open MockMember

let SomeDeductable = { Total=100m; Spent=50m } 

let inNetwork = { 
    PreventiveAndDiagnostic= PreventiveAndDiagnostic 100
    Restoration=             Restoration  100
    OralSurgery=             OralSurgery  100
    Periodontics=            Periodontics 100 }

let outOfNetwork = { 
    PreventiveAndDiagnostic= PreventiveAndDiagnostic 100
    Restoration=             Restoration  100
    OralSurgery=             OralSurgery  100
    Periodontics=            Periodontics 100 }

let networks = { InNetwork= inNetwork ; OutOfNetwork=outOfNetwork }

let summary:Summary = {
    Deductable=SomeDeductable
    OutOfPocket=OutOfPocket     100m
    AnnualMaximum=AnnualMaximum 100m
    Networks=networks }

let SomeIdCard = { 
    MemberId=    SomeMemberId
    Name=        SomeName
    DateOfBirth= DateOfBirth SomeDateOfBirth
    Zipcode=     SomeZipCode }

let anonymousUsage =    { Deductable=SomeDeductable; OutOfPocket=OutOfPocket 100m }
let anonymousCoverage = { Member=SomeIdCard ; Summary=summary }
let anonymousOverview = { Coverage= anonymousCoverage ; Usage=anonymousUsage }