namespace Repositories

open Account
open Claims

type IProvidersRepository =
    
    abstract member GetProvidersByName      : Name      -> ProviderByName seq
    abstract member GetProvidersBySpecialty : Specialty -> ProviderByName seq
    abstract member GetSpecialties          : unit      -> string seq
    abstract member GetNetworks             : unit      -> string seq
    abstract member GetDistances            : unit      -> int seq