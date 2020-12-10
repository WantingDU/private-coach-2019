using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticItems : MonoBehaviour
{
    public static string userID { set; get; }
    public static string mail { set; get; }
    public static string password { set; get; }
    public static string username{ set; get; }
    private void Start()
    {
        if (userID == null) userID = "default ID";
        mail = "skynet@insa.com";
        password = "123456789";
        username = "dubiName";
    }
    private void OnDestroy()
    {
        
    }
}
