namespace TestAPI

open Repositories
open Contact
open MockMember

type MockCompanyRepository() =

    interface ICompanyRepository with

        member this.GetContactInfo companyId = Some { Phone=Phone "555.555.5555" ; Email=SomeEmail }
        member this.GetCompanyId   patientId = Some SomeCompanyId