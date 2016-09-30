[<System.Diagnostics.DebuggerNonUserCode>]
module Benefits

    open Account
    open System

    type Deductable = { Total:decimal ; Spent:decimal }
                      member this.Remaining() = this.Total - this.Spent

    type OutOfPocket =   OutOfPocket   of decimal
    type AnnualMaximum = AnnualMaximum of decimal

    type PreventiveAndDiagnostic = PreventiveAndDiagnostic of int
    type Restoration =             Restoration  of int
    type OralSurgery =             OralSurgery  of int
    type Periodontics =            Periodontics of int

    type Network = { 
        PreventiveAndDiagnostic:PreventiveAndDiagnostic
        Restoration:Restoration
        OralSurgery:OralSurgery
        Periodontics:Periodontics
    }

    type Networks = {
        InNetwork:Network
        OutOfNetwork:Network
    }

    type ActiveFrom  = ActiveFrom  of DateTime
    type ActiveUntil = ActiveUntil of DateTime

    type Efective = {
        ActiveFrom:ActiveFrom
        ActiveUntil:ActiveUntil
    }

    type PlanType =    PlanType    of string
    type NetworkName = NetworkName of string
    type GroupNumber = GroupNumber of string

    type Summary = {
        Deductable:Deductable
        OutOfPocket:OutOfPocket
        AnnualMaximum:AnnualMaximum
        NetworkName:NetworkName
        NetworkCoverage:Network
        Effective:Efective
        PlanType:PlanType
        GroupNumber:GroupNumber
    }

    type MemberPlan =    { Member:IdCard ; Summary:Summary }
    type BenefitsUsage = { Deductable:Deductable ; OutOfPocket:OutOfPocket }
    type MemberUsage =   { Member:IdCard ; Usage:BenefitsUsage }

    type BenefitsOverview = {
        Coverage:MemberPlan
        Usage:BenefitsUsage
    }

    type Appointment = { Date:DateTime }