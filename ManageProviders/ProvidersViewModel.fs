namespace ManageProviders

open System.Windows.Input
open InteractionLogic

type ProvidersViewModel(dispatcher:Dispatcher) =

    let mutable hideOptions = true
    let mutable providers = seq []
    let mutable provider = None

    member this.HideOptions
        with get() = hideOptions
        and private set(value) = hideOptions <- value

    member this.Providers
        with get() = providers
        and private set(value) = providers <- value

    member this.SelectedProvider
        with get() = provider
        and private set(value) = provider <- value


    member this.ViewOptions =
        DelegateCommand ( (fun _ -> this.HideOptions <- not this.HideOptions) , 
                           fun _ -> true ) :> ICommand

    member this.AddAsContact =
        DelegateCommand ( (fun _ -> dispatcher.AddContact this.SelectedProvider) , 
                           fun _ -> true ) :> ICommand

    member this.EmailProviders =
        DelegateCommand ( (fun _ -> dispatcher.EmailProviders this.Providers) , 
                           fun _ -> true ) :> ICommand

    member this.TextMessageProviders =
        DelegateCommand ( (fun _ -> dispatcher.TextMessageProviders this.Providers) , 
                           fun _ -> true ) :> ICommand