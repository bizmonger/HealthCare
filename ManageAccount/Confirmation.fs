module Confirmation

open System

type MyDelegate = delegate of obj * EventArgs -> unit

type IConfirmation =

    [<CLIEvent>]
    abstract member Show : IEvent<MyDelegate,EventArgs>
    abstract member Display : unit -> unit

type TryAgainConfirmation() =

    let show = new Event<MyDelegate,EventArgs>()

    interface IConfirmation with
        [<CLIEvent>]
        member this.Show =      show.Publish
        member this.Display() = show.Trigger(this,EventArgs())