[<System.Diagnostics.DebuggerNonUserCode>]
module ValidationTrack

type Result<'TSuccess,'TFailure> = 
    | Success of 'TSuccess
    | Failure of 'TFailure

let bind switchFunction twoTrackInput = 
    match twoTrackInput with
    | Success s -> switchFunction s
    | Failure f -> Failure f

let failOnEmpty container error field =
    if field = "" 
    then Failure error
    else Success container