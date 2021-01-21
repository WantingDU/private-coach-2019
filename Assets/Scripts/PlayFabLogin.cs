using PlayFab;
using PlayFab.ClientModels;
using PlayFab.SharedModels;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Lean.Gui;

public class PlayFabLogin : MonoBehaviour
{
    public InputField MailIn;
    public InputField PasswordIn;
    public InputField Username;
    public CanvasGroup SignInComponents;

    private GameObject MessagePulse;
    private Text MessageText;
   

    public void Start()
    {
        SignInComponents.alpha = 0;
        SignInComponents.blocksRaycasts = false;
        SignInComponents.interactable = false;
        MessagePulse = GameObject.Find("Notification");
        MessageText =MessagePulse.transform.GetComponentInChildren<Text>();

        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            Please change the titleId below to your own titleId from PlayFab Game Manager.
            If you have already set the value in the Editor Extensions, this can be skipped.
            */
            PlayFabSettings.staticSettings.TitleId = "A364D";
        }
        
        PlayerPrefs.DeleteAll();
        //var request = new LoginWithCustomIDRequest { CustomId = StaticItems.userID, CreateAccount = true };
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you log in successfully!");
        PlayerPrefs.SetString("EMAIL", StaticItems.mail);
        PlayerPrefs.SetString("PASSWORD", StaticItems.password);
        PlayerPrefs.SetString("USERNAME", StaticItems.username);
        MessageText.text = "Congratulations, log in successful!";
        MessagePulse.GetComponent<LeanPulse>().Pulse();
        OnSkip();
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        if (error.Error.ToString()=="AccountNotFound")
        {
            MessageText.text = "This account doesn't exist, maybe try to sign up ? ";
            onClickSignIn();
        }
        else
        {
            MessageText.text = "Login failed: " + error.GenerateErrorReport()+", please retry";
        }
        MessagePulse.GetComponent<LeanPulse>().Pulse();


    }

    private void onRegisterSucces(RegisterPlayFabUserResult result)
    {
        Debug.Log("Congratulations, you registered successful your account!");
        MessageText.text = "Congratulations, you registered successful!";
        MessagePulse.GetComponent<LeanPulse>().Pulse();
        PlayerPrefs.SetString("EMAIL", StaticItems.mail);
        PlayerPrefs.SetString("PASSWORD", StaticItems.password);
        PlayerPrefs.SetString("USERNAME", StaticItems.username);
    }
    private void onRegisterFailure(PlayFabError error)
    {
        Debug.LogError("Failed to register your account!");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
        MessageText.text = "Sorry, Failed to register your account!"+error.GenerateErrorReport();
        MessagePulse.GetComponent<LeanPulse>().Pulse();
    }
    public void onClickLogin()
    {
        StaticItems.mail = MailIn.text;
        StaticItems.password = PasswordIn.text;
        /*
        if (PlayerPrefs.HasKey("EMAIL"))
        {
            print(PlayerPrefs.GetString("EMAIL"));
            Debug.Log("User info exists locally");
            var requestMail = new LoginWithEmailAddressRequest { Email = PlayerPrefs.GetString("EMAIL"), Password = PlayerPrefs.GetString("PASSWORD") };
            PlayFabClientAPI.LoginWithEmailAddress(requestMail, OnLoginSuccess, OnLoginFailure);
        }
        else
        {*/
            print(StaticItems.mail +" Password = " +StaticItems.password);
            var requestMail = new LoginWithEmailAddressRequest { Email = StaticItems.mail, Password = StaticItems.password };
            PlayFabClientAPI.LoginWithEmailAddress(requestMail, OnLoginSuccess, OnLoginFailure);


        //}

    }
    public void onClickRegister()
    {
        StaticItems.mail = MailIn.text;
        StaticItems.password = PasswordIn.text;
        StaticItems.username = Username.text;
        var requestRegist = new RegisterPlayFabUserRequest { Email = StaticItems.mail, Password = StaticItems.password, Username = StaticItems.username };
        PlayFabClientAPI.RegisterPlayFabUser(requestRegist, onRegisterSucces, onRegisterFailure);
    }
    public void OnSkip()
    {
        SceneManager.LoadScene(1);
    }
    public void onClickSignIn()
    {
        SignInComponents.alpha = 1;
        SignInComponents.blocksRaycasts = true;
        SignInComponents.interactable = true;
        var cg=GameObject.Find("SignIn2").GetComponent<CanvasGroup>();
        cg.alpha = 0;
        cg.blocksRaycasts = false;
        cg.interactable = false;
    }
}