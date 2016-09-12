namespace TestAPI

open Repositories
open ManageProviders
open MockClaim

type MockProvidersRepository() =

    interface IProvidersRepository with
        member this.GetProvidersByName      name = SomeProviders
        member this.GetProvidersBySpecialty name = SomeProviders