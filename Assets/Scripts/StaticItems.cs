
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using Debug = UnityEngine.Debug;
using System.Linq;
using System;

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
    public static List<int> ChoosedAngles = new List<int>(new int[] { 0,1,2,3,4,5,6,7,8,9 }); 

    private void Awake()
    {
        Coach = GameObject.Find("godot");
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
        Avg_text = GameObject.Find("Avg_score").GetComponent<Text>();
        CountDown = GameObject.Find("countDown").GetComponent<Text>();
        StaticItems.CountDown.gameObject.SetActive(false);
        //ChoosedAngles.Add(1);
        //ChoosedAngles.Add(3);
        /*
        if (userID == null) userID = "default ID";
        mail = "skynet@insa.com";
        password = "123456789";
        username = "dubiName";
        */

    }
    public static void ClientGetTitleData(string sportName)
    {
        PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(),
            result => {
                if (result.Data == null || !result.Data.ContainsKey(sportName)) Debug.Log("No " + sportName);
                else
                {
                    Debug.Log(sportName + ": " + result.Data[sportName]);
                    print("result split:"+result.Data[sportName].Split(new char[] { ',' }).Select(Int32.Parse).ToList());
                    ChoosedAngles = result.Data[sportName].Split(new char[] { ',' }).Select(Int32.Parse).ToList();
                }
            },
            error => {
                Debug.Log("Got error getting titleData:");
                Debug.Log(error.GenerateErrorReport());
            }
        );
    }
    private void OnDestroy()
    {
        
    }


    

}
