namespace Repositories

open Account
open System

type IProfileRepository =

    abstract member GetProfile      : MemberId -> Profile option
    abstract member GetDependents   : MemberId -> Profile list
    abstract member GetLastCleaning : MemberId -> DateTime option
    abstract member GetLastVisit    : MemberId -> DateTime option
    abstract member Save            : Profile  -> unit