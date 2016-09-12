module FindProviders

type ProvidersByNameResponse =
    | NA
    | FirstNameRequired
    | LastNameRequired
    | OfficeRequired
    | NetworkRequired

type ProvidersBySpecialtyResponse =
    | NA
    | SpecialtyRequired
    | DistanceRequired
    | LocationRequired