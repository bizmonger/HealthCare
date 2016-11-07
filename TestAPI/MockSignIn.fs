module MockSignIn

open ManageAccount
open SignIn

let signIn credentials dispatcher =

    let patientId = match credentials.PatientId with Account.PatientId patientId -> patientId
    let password  = match credentials.Password  with Account.Password pwd       -> pwd

    let signInViewModel = SignInViewModel(dispatcher)
    signInViewModel.PatientId <- patientId
    signInViewModel.Password  <- password
    signInViewModel.SignIn.Execute()