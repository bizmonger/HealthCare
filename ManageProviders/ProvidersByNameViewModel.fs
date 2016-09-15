namespace ManageProviders

open System.Windows.Input
open InteractionLogic
open ValidationTrack
open Repositories
open Account
open FindProviders
open Validation
open Claims
open Benefits

type ProvidersByNameViewModel(memberId:MemberId , repository:IProvidersRepository) =

    let network = { PreventiveAndDiagnostic= PreventiveAndDiagnostic 0
                    Restoration=             Restoration  0
                    OralSurgery=             OralSurgery  0
                    Periodontics=            Periodontics 0 }

    member val FirstName =  ""   with get,set
    member val MiddleName = None with get,set
    member val LastName =   ""   with get,set

    member val Office = ""       with get,set
    member val Network = network with get,set

    member val ValidationResult = Failure ProvidersByNameResponse.NA with get,set
    member val Providers = []   with get,set

    member this.Validate() = this.ValidationResult <- validateProviderByName { Name = { First=  this.FirstName
                                                                                        Middle= this.MiddleName
                                                                                        Last= this.LastName }
                                                                               Office=  Office this.Office
                                                                               Network= this.Network }
    member this.LoadProviders =
        DelegateCommand ( (fun _ -> this.Validate()
        
                                    match this.ValidationResult with
                                    | Failure reason -> this.Providers <- []
                                    | Success v      -> this.Providers <- repository.GetProvidersByName { First=  this.FirstName
                                                                                                          Middle= this.MiddleName
                                                                                                          Last= this.LastName }) , 
                           fun _ -> true ) :> ICommand