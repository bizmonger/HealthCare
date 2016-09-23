namespace ManageAccount

open Account

type AccountViewModel(memberId , dispatcher , repository) =

    member val AccountNumber = AccountNumber "need value" with get,set