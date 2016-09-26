namespace InteractionLogic

open Settings
open Account
open System
open Claims
open System.Diagnostics

[<DebuggerNonUserCode>]
type Dispatcher() =

    let signInRequested =       new Event<EventHandler<_>,_>()
    let signInSuccessful =      new Event<EventHandler<_>,_>()

    let registrationRequested = new Event<EventHandler<_>,_>()
    let receivedValidForm =     new Event<EventHandler<_>,_>()

    let settingsChanged =       new Event<Features>()

    let idRequested =           new Event<EventHandler<_>,_>()
    let accountRequested =      new Event<EventHandler<_>,_>()
    let contactRequested =      new Event<EventHandler<_>,_>()
    let viewProvidersRequested =new Event<EventHandler<_>,_>()
    let findProvidersRequested =new Event<EventHandler<_>,_>()
    let tipsRequested =         new Event<EventHandler<_>,_>()
    let infoRequested =         new Event<EventHandler<_>,_>()
    let privacyRequested =      new Event<EventHandler<_>,_>()
    let faqRequested =          new Event<EventHandler<_>,_>()

    let planRequested =         new Event<EventHandler<_>,_>()
    let coverageRequested =     new Event<EventHandler<_>,_>()
    let usageRequested =        new Event<EventHandler<_>,_>()  
    
    let inNetworkRequested =    new Event<EventHandler<_>,_>()      
    let outOfNetworkRequested = new Event<EventHandler<_>,_>()      
    let preventiveAndDiagnosticsRequested = new Event<EventHandler<_>,_>()      
    let restorationRequested =  new Event<EventHandler<_>,_>()      
    let oralSurgeryRequested =  new Event<EventHandler<_>,_>()      
    let periodonticsRequested = new Event<EventHandler<_>,_>()  
    
    let profileRequested =          new Event<EventHandler<_>,_>()
    let dependentProfilesRequested= new Event<EventHandler<_>,_>()
    let loginSettingsRequested  =   new Event<EventHandler<_>,_>()
    let familyClaimsRequested =     new Event<EventHandler<_>,_>()
    let claimRequested        =     new Event<EventHandler<_>,_>()
    let memberClaimsRequested =     new Event<EventHandler<_>,_>()

    let printIdCardRequested =  new Event<EventHandler<_>,_>()
    let emailIdRequested =      new Event<EventHandler<_>,_>()
    let callSupportRequested =  new Event<EventHandler<_>,_>()
    let emailSupportRequested = new Event<EventHandler<_>,_>()

    let serviceDetailsRequested = new Event<EventHandler<_>,_>()
    let paymentDetailsRequested = new Event<EventHandler<_>,_>()

    let addContactRequested = new Event<EventHandler<_>,_>()
    let emailProvidersRequested = new Event<EventHandler<_>,_>()
    let textMessageProvidersRequested = new Event<EventHandler<_>,_>()

    [<CLIEvent>]
    member this.SettingsChanged =       settingsChanged.Publish

    [<CLIEvent>]
    member this.IdRequested =           idRequested.Publish
    [<CLIEvent>]
    member this.AccountRequested =      accountRequested.Publish

    [<CLIEvent>]
    member this.ProfileRequested  =      profileRequested.Publish
    [<CLIEvent>]
    member this.DependentProfilesRequested = dependentProfilesRequested.Publish
    [<CLIEvent>]
    member this.LoginSettingsRequested = loginSettingsRequested.Publish

    [<CLIEvent>]                        
    member this.ContactRequested =      contactRequested.Publish
    [<CLIEvent>]
    member this.FindProvidersRequested =findProvidersRequested.Publish
    [<CLIEvent>]
    member this.ProvidersRequested =viewProvidersRequested.Publish
    [<CLIEvent>]
    member this.InfoRequested =         infoRequested.Publish
    [<CLIEvent>]
    member this.PrivacyRequested =      privacyRequested.Publish
    [<CLIEvent>]
    member this.FAQRequested =          faqRequested.Publish
    [<CLIEvent>]
    member this.TipsRequested =         tipsRequested.Publish
    [<CLIEvent>]
    member this.PlanRequested =         planRequested.Publish
    [<CLIEvent>]
    member this.CoverageRequested =     coverageRequested.Publish
    [<CLIEvent>]
    member this.UsageRequested =        usageRequested.Publish

    [<CLIEvent>]
    member this.InNetworkRequested = inNetworkRequested.Publish
    [<CLIEvent>]
    member this.OutOfNetworkRequested = outOfNetworkRequested.Publish
    [<CLIEvent>]
    member this.PreventiveAndDiagnosticsRequested = preventiveAndDiagnosticsRequested.Publish
    [<CLIEvent>]
    member this.RestorationRequested =    restorationRequested.Publish
    [<CLIEvent>]                          
    member this.OralSurgeryRequested =    oralSurgeryRequested.Publish
    [<CLIEvent>]                         
    member this.PeriodonticsRequested =   periodonticsRequested.Publish    
    [<CLIEvent>]
    member this.ServiceDetailsRequested = serviceDetailsRequested.Publish
    [<CLIEvent>]
    member this.PaymentDetailsRequested = paymentDetailsRequested.Publish

    [<CLIEvent>]
    member this.FamilyClaimsRequested =   familyClaimsRequested.Publish
    [<CLIEvent>]
    member this.MemberClaimsRequested =   memberClaimsRequested.Publish
    [<CLIEvent>]
    member this.ClaimRequested =          claimRequested.Publish
                                          
    [<CLIEvent>]                          
    member this.PrintIdRequested =        printIdCardRequested.Publish
    [<CLIEvent>]                          
    member this.EmailIdRequested =        emailIdRequested.Publish  
    [<CLIEvent>]                          
    member this.CallSupportRequested =    callSupportRequested.Publish
    [<CLIEvent>]                          
    member this.EmailSupportRequested =   emailSupportRequested.Publish
    [<CLIEvent>]
    member this.AddContactRequested =     addContactRequested.Publish
    [<CLIEvent>]
    member this.EmailProvidersRequested = emailProvidersRequested.Publish
    [<CLIEvent>]
    member this.TextMessageProvidersRequested = textMessageProvidersRequested.Publish
    [<CLIEvent>]
    member this.SignInRequested =         signInRequested.Publish
    [<CLIEvent>]
    member this.SignInSuccessful =        signInSuccessful.Publish

    [<CLIEvent>]
    member this.RegistrationRequested =   registrationRequested.Publish

    [<CLIEvent>]
    member this.RegistrationSuccessful =  receivedValidForm.Publish

    (* Triggers *)
    member this.ViewPortalDashboard() =    signInSuccessful.Trigger(this , EventArgs.Empty)
    member this.RegistrationIsValid form = receivedValidForm.Trigger(this, form)
    member this.ChangeSettings settings =  settingsChanged.Trigger settings

    member this.TryViewIdCard memberId =         idRequested.Trigger(this , EventArgs.Empty)
    member this.ViewAccount memberId =           accountRequested.Trigger(this, EventArgs.Empty) 
    member this.ViewDependentProfiles memberId = dependentProfilesRequested.Trigger(this, EventArgs.Empty) 
    member this.ViewLoginSettings memberId =     loginSettingsRequested.Trigger(this, EventArgs.Empty) 
    member this.ViewContact() =                  contactRequested.Trigger(this , EventArgs.Empty)
    member this.FindProviders() =                findProvidersRequested.Trigger(this , EventArgs.Empty)
    member this.ViewProviders providers =        viewProvidersRequested.Trigger(this , providers)
    member this.ViewTips() =                     tipsRequested.Trigger(this , EventArgs.Empty)
    member this.ViewInfo() =                     infoRequested.Trigger(this , EventArgs.Empty)
    member this.ViewPrivacy() =                  privacyRequested.Trigger(this , EventArgs.Empty)
    member this.ViewFAQ() =                      faqRequested.Trigger(this , EventArgs.Empty)
    member this.ViewSignIn() =                   signInRequested.Trigger(this , EventArgs.Empty)
    member this.ViewRegistration() =             registrationRequested.Trigger(this , EventArgs.Empty)

    member this.ViewPlan memberId =      planRequested.Trigger (this , memberId)
    member this.ViewCoverage memberId =  coverageRequested.Trigger (this , memberId)
    member this.ViewUsage memberId =     usageRequested.Trigger (this , memberId)

    member this.ViewInNetwork memberId =               inNetworkRequested.Trigger (this , memberId)
    member this.ViewOutOfNetwork memberId =            outOfNetworkRequested.Trigger (this , memberId)
    member this.ViewPreventiveAndDiagnostic memberId = preventiveAndDiagnosticsRequested.Trigger (this , memberId)
    member this.ViewRestoration memberId =             restorationRequested.Trigger (this , memberId)
    member this.ViewOralSurgery memberId =             oralSurgeryRequested.Trigger (this , memberId)
    member this.ViewPeriodontics memberId =            periodonticsRequested.Trigger (this , memberId)

    member this.ViewServiceDetails claimId =           serviceDetailsRequested.Trigger (this , claimId)
    member this.ViewPaymentDetails claimId =           paymentDetailsRequested.Trigger (this , claimId)

    member this.ViewProfile memberId =                 profileRequested.Trigger (this , memberId)
    member this.ViewDependentProfiles memberId =       dependentProfilesRequested.Trigger(this , memberId)
    member this.ViewLoginSettings memberId =           loginSettingsRequested.Trigger(this , memberId)
    member this.ViewFamilyClaims memberId =            familyClaimsRequested.Trigger (this , memberId)
    member this.ViewMemberClaims memberId =            memberClaimsRequested.Trigger (this , memberId)
    member this.ViewClaim claimId =                    claimRequested.Trigger (this , claimId)

    member this.PrintId idCard = printIdCardRequested.Trigger (this , idCard)
    member this.EmailId idCard = emailIdRequested.Trigger (this , idCard)
    member this.CallSupport()  = callSupportRequested.Trigger(this , EventArgs.Empty)
    member this.EmailSupport() = emailSupportRequested.Trigger(this , EventArgs.Empty)

    member this.AddContact     provider =        addContactRequested.Trigger(this , provider)
    member this.EmailProviders providers =       emailProvidersRequested.Trigger(this , providers)
    member this.TextMessageProviders providers = textMessageProvidersRequested.Trigger (this, providers)