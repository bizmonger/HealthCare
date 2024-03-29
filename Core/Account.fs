﻿
[<System.Diagnostics.DebuggerNonUserCode>]
module Account

    open System
    open Contact

    type PatientId =     PatientId     of string
    type AccountNumber = AccountNumber of string
    type CompanyId =     CompanyId     of string
    type Password =      Password      of string

    type Name = { 
        First:string
        Middle:string option
        Last:string 
    }

    type Street =      Street of string
    type City =        City   of string
    type State =       State  of string

    type Phones = {
        Home:PhoneNumber
        Work:PhoneNumber
        Mobile:PhoneNumber
    }

    type DateOfBirth = DateOfBirth of string
    type ZipCode =     ZipCode     of int

    type IdCard = {
        PatientId:PatientId
        Name:Name
        DateOfBirth:DateOfBirth
        Zipcode : ZipCode
    }

    type Address = {
        Address1:Street
        Address2:Street
        City:City
        State:State
        Zipcode:ZipCode
    }

    type SSN = SSN of int

    type Profile = {
        SSN:SSN
        IdCard:IdCard
        Address:Address
        Email:Email
        Phones:Phones
    }

    type PasswordChange = {
        PatientId:PatientId
        Old:Password
        New:Password
    }

    type File = File of string