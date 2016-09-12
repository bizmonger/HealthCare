namespace Repositories

open Account

type IProfileRepository =

    abstract member GetProfile    : MemberId -> Profile option
    abstract member GetDependents : MemberId -> Profile list
    abstract member Save          : Profile  -> unit