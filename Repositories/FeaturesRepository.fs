namespace Repositories

open Settings

type FeatureSettings() =
    
    let mutable features = { ViewIdCardFromHome=false }

    member this.Save update = features <- update
    member this.Get() = features