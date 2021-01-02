
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Collections.Generic;

public class StaticItems : MonoBehaviour
{

    public static string userID { set; get; }
    public static string mail { set; get; }
    public static string password { set; get; }
    public static string username { set; get; }
    public static GameObject Coach;
    public static Text Avg_text;
    public static Text ScoreText;
    public static Text CountDown;
    public static string AnimName;
    //public static List<int> ChoosedAngles= new List<int>();
    public static List<int> ChoosedAngles = new List<int>(new int[] { 1,  3, 4, 5, 6, 7, 8, 9 }); 

    private void Awake()
    {
        Coach = GameObject.Find("godot");
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
        Avg_text = GameObject.Find("Avg_score").GetComponent<Text>();
        CountDown = GameObject.Find("countDown").GetComponent<Text>();
        //ChoosedAngles.Add(1);
        //ChoosedAngles.Add(3);
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
