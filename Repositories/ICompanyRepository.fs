namespace Repositories

open Contact
open Account

type ICompanyRepository =

    abstract member GetContactInfo : CompanyId -> ContactInfo
