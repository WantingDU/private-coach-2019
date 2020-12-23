
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;


public class StaticItems : MonoBehaviour
{

    public static string userID { set; get; }
    public static string mail { set; get; }
    public static string password { set; get; }
    public static string username{ set; get; }
    public static GameObject Coach;
    public static Text Avg_text;
    public static Text ScoreText;
    public static Text CountDown;
    //public static string InfoMessage { set; get; }
    private void Awake()
    {
        Coach = GameObject.Find("godot");
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
        Avg_text = GameObject.Find("Avg_score").GetComponent<Text>();

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

    public static void Delay(int millisecond)
    {
        
        Stopwatch sw = new Stopwatch();
        sw.Start();
        bool flag = false;
        while (!flag)
        {
            if (sw.ElapsedMilliseconds > millisecond)
            {
                flag = true;
            }
        }
        sw.Stop();
    }

}
