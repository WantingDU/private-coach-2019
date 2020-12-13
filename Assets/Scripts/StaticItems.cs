
using UnityEngine;


public class StaticItems : MonoBehaviour
{

    public static string userID { set; get; }
    public static string mail { set; get; }
    public static string password { set; get; }
    public static string username{ set; get; }
    public static GameObject Coach;
    //public static string InfoMessage { set; get; }
    private void Start()
    {
        Coach = GameObject.Find("godot");
        /*
        if (userID == null) userID = "default ID";
        mail = "skynet@insa.com";
        password = "123456789";
        username = "dubiName";
        */
    }
    private void OnDestroy()
    {
        
    }
}
