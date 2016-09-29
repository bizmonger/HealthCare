namespace ManageAccount

open System.Windows.Input
open System
open InteractionLogic
open Repositories
open Account
open Contact


type EditProfileViewModel(memberId:MemberId , repository:IProfileRepository) =

    member val SSN  = "" with get,set
    member val First  = "" with get,set
    member val Middle = "" with get,set
    member val Last   = "" with get,set

    member val DateOfBirth = "" with get,set

    member val Email  = "" with get,set
    member val Home   = "" with get,set
    member val Work   = "" with get,set
    member val Mobile = "" with get,set

    member val Address1 = "" with get,set
    member val Address2 = "" with get,set
    member val City     = "" with get,set
    member val State    = "" with get,set
    member val ZipCode  = "" with get,set

    member this.Save =
        
        let name = { First=this.First
                     Middle=Some this.Middle
                     Last=this.Last }

        let idCard = { MemberId=memberId
                       Name=name
                       DateOfBirth=DateOfBirth this.DateOfBirth
                       Zipcode= ZipCode (Int32.Parse( this.ZipCode )) }

        let address = { Address1=Street this.Address1
                        Address2=Street this.Address2
                        City=    City this.City
                        State=   State this.State
                        Zipcode= ZipCode (Int32.Parse(this.ZipCode)) }

        let phones = { Home = Phone this.Home
                       Work = Phone this.Work
                       Mobile    = Phone this.Mobile }

        DelegateCommand ( (fun _ -> repository.Save { SSN=SSN (Int32.Parse(this.SSN))
                                                      IdCard=idCard
                                                      Address=address
                                                      Email= Email this.Email
                                                      Phones=phones
                                                  } ) , fun _ -> true ) :> ICommand