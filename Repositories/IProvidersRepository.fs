namespace Repositories

open Account
open Claims

type IProvidersRepository =
    
    abstract member GetProvidersByName      : Name      -> ProviderByName list
    abstract member GetProvidersBySpecialty : Specialty -> ProviderByName list