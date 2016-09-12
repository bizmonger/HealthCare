module ManageProviders

open Account
open Claims

type IProvidersRepository =
    
    abstract member GetProvidersByName      : Name      -> Provider list
    abstract member GetProvidersBySpecialty : Specialty -> Provider list