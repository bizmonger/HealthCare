namespace ManageBenefits

open System.Windows.Input
open InteractionLogic
open Account
open Repositories
open Benefits

type BenefitsPlanViewModel(companyId, patientId, dispatcher:Dispatcher, repository:IBenefitsRepository) =

    member val InNetworkUsage =           None with get,set
    member val OutOfNetworkNetworkUsage = None with get,set
    member val Members =                  seq [] with get,set
    member val Services =                 seq [] with get,set

    member this.Load() =

        this.InNetworkUsage           <- repository.GetUsage           patientId
        this.OutOfNetworkNetworkUsage <- repository.GetUsage           patientId
        this.Members                  <- repository.GetMemberCoverages patientId
        this.Services                 <- repository.GetServices        companyId