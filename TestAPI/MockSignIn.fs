module MockSignIn

open ManageAccount
open SignIn

let signIn credentials dispatcher =

    let user =     match credentials.User     with User     user -> user
    let password = match credentials.Password with Password pwd  -> pwd

    let signInViewModel = SignInViewModel(dispatcher)
    signInViewModel.UserName <- user
    signInViewModel.Password <- password
    signInViewModel.SignIn.Execute()