﻿module MockMember

open Account
open Benefits

(*Account Info*)
let SomeMemberId =    MemberId "some_member_id"
let SomePhone =       Phone "555.555.5555"
let SomeEmail =       Email "some_name@some_website.com"
let SomeZipCode =     ZipCode 55555
let SomeFirstName =   "some_first_name"
let SomeLastName =    "some_last_name"
let SomeUser =        "some_user_name"
let SomePassword =    "some_password"
let SomeDateOfBirth = "some_dob"

let SomeName = { First=SomeFirstName; Middle=None; Last =SomeLastName }

let SomeIdCard = {
    MemberId = SomeMemberId
    Name = SomeName
    DateOfBirth = DateOfBirth SomeDateOfBirth
    Zipcode = SomeZipCode
}

let SomeMembers = seq [SomeIdCard]

let SomeSSN = SSN 123456789

let SomeStreet1 = Street "some_street_1"
let SomeStreet2 = Street "some_street_2"
let SomeCity =    City "some_city"
let SomeState =   State "some_state"

let SomeAddress = {
    Address1= SomeStreet1
    Address2= SomeStreet2
    City= SomeCity
    State= SomeState
    Zipcode= SomeZipCode
}

let SomeProfile = {
    SSN=SomeSSN
    IdCard=SomeIdCard
    Address=SomeAddress
    Email=SomeEmail
    Phones= { Home=  SomePhone
              Work=  SomePhone
              Mobile=SomePhone }
}

let SomeAppointment = {
    Date=System.DateTime.Now
}