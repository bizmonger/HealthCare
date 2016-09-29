namespace TestAPI

open Repositories
open Contact
open MockMember

type MockCompanyRepository() =

    interface ICompanyRepository with

        member this.GetContactInfo companyId = { Phone=Phone "555.555.5555" ; Email=SomeEmail }

