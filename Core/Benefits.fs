[<System.Diagnostics.DebuggerNonUserCode>]
module Benefits

    open Account
    open System

    type Deductable = { Total:decimal ; Spent:decimal }
                      member this.Remaining() = this.Total - this.Spent

    type OutOfPocket =   OutOfPocket   of decimal
    type AnnualMaximum = AnnualMaximum of decimal

    type PreventiveAndDiagnostic = PreventiveAndDiagnostic of int
    type Restoration =  Restoration  of int
    type OralSurgery =  OralSurgery  of int
    type Periodontics = Periodontics of int

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

    type Summary = {
        Deductable:Deductable
        OutOfPocket:OutOfPocket
        AnnualMaximum:AnnualMaximum
        Networks:Networks
    }

    type MemberPlan =    { Member:IdCard ; Summary:Summary }
    type BenefitsUsage = { Deductable:Deductable ; OutOfPocket:OutOfPocket }
    type MemberUsage =   { Member:IdCard ; Usage:BenefitsUsage }

    type BenefitsOverview = {
        Coverage:MemberPlan
        Usage:BenefitsUsage
    }

    type Appointment = { Date:DateTime }