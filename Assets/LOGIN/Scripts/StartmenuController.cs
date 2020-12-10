using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartmenuController : MonoBehaviour
{
    public string username;
    public string password;
    public InputField Username;//登录面板输入用户名
    public InputField Password;//登录面板输入密码

    public void OnLogin()
    {
        username = Username.text;
        password = Password.text;
        print(username);
        print(password);
    }

    public void OnSkip()
    {
        SceneManager.LoadScene("Scene2");
    }
}
