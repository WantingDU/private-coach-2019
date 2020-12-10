using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour
{
    public void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            Please change the titleId below to your own titleId from PlayFab Game Manager.
            If you have already set the value in the Editor Extensions, this can be skipped.
            */
            PlayFabSettings.staticSettings.TitleId = "A364D";
        }
        StaticItems.userID = "dudu";
        //var request = new LoginWithCustomIDRequest { CustomId = StaticItems.userID, CreateAccount = true };
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        PlayerPrefs.SetString("EMAIL",StaticItems.mail);
        PlayerPrefs.SetString("PASSWORD", StaticItems.password);
        PlayerPrefs.SetString("USERNAME", StaticItems.username);

    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
        Debug.Log("signing up with current email and pw");
        var requestRegist = new RegisterPlayFabUserRequest {Email = StaticItems.mail, Password = StaticItems.password, Username = StaticItems.username };
        PlayFabClientAPI.RegisterPlayFabUser(requestRegist, onRegisterSucces, onRegisterFailure);
    }
    private void onRegisterSucces(RegisterPlayFabUserResult result)
    {
        Debug.Log("Congratulations, you registered successful your account!");
    }
    private void onRegisterFailure(PlayFabError error)
    {
        Debug.LogError("Failed to register your account!");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
    public void onClickLogin()
    {
        if (PlayerPrefs.HasKey("EMAIL"))
        {
            Debug.Log("User info exists locally");
            var requestMail = new LoginWithEmailAddressRequest { Email = PlayerPrefs.GetString("EMAIL"), Password = PlayerPrefs.GetString("PASSWORD") };
            PlayFabClientAPI.LoginWithEmailAddress(requestMail, OnLoginSuccess, OnLoginFailure);
        }
        else
        {
            var requestMail = new LoginWithEmailAddressRequest { Email = StaticItems.mail, Password = StaticItems.password };
            PlayFabClientAPI.LoginWithEmailAddress(requestMail, OnLoginSuccess, OnLoginFailure);
        }

    }
}