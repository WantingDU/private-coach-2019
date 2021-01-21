
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using Debug = UnityEngine.Debug;
using System.Linq;
using System;
using Lean.Gui;

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
    public static Text AdviseText;
    public static GameObject Notification;
    public static Text Timer;
    public static string AnimName;
    public static double sportDuration { set; get; }
    public static int elapsedTime;
    public static float eval_standard { set; get; }
    public static List<int> ChoosedAngles = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
    public static List<int> ChoosedAngles_default = new List<int>(new int[] { 0, 1, 2, 3 });// change here for local choice
    public static int frameInterval = 300;
    public static int messageRate { set; get; }
    public static string ErrorMessage;
    public static string difficulty { set; get; }
    public static string ErrorTime;
    public static int[] errorStatistics=new int[10];
    public static double[] scoresStatistics = new double[10];
    public static int[] frameCounter=new int[10];
    public void sportDuration_string() {
        string sportDuration_string = GameObject.Find("inputText_duration").GetComponent<Text>().text;
        sportDuration= double.Parse(sportDuration_string);
    }
    public void leftWindowHide()
    {
        GameObject.Find("Left Box").GetComponent<LeanSnap>().SnapWrapper(-1000f);
    }
    private void Awake()
    {
        eval_standard = 0.7f;
        frameInterval = 300;
        messageRate = 50;
        difficulty = "Easy";
        sportDuration = 1;//default 1 min
        Coach = GameObject.Find("godot");
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
        Avg_text = GameObject.Find("Avg_score").GetComponent<Text>();
        CountDown = GameObject.Find("countDown").GetComponent<Text>();
        //AdviseText = GameObject.Find("AdviseText").GetComponent<Text>();
        Notification = GameObject.Find("Notification").gameObject;
        AdviseText = GameObject.Find("Notification").GetComponentInChildren<Text>();
        Timer = GameObject.Find("Timer").GetComponent<Text>();
        StaticItems.CountDown.gameObject.SetActive(false);


    }
    public static void ClientGetTitleData(string sportName)
    {
        PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(),
            result => {
                if (result.Data == null || !result.Data.ContainsKey(sportName))
                {
                    Debug.Log("No " + sportName + ", set to default.");
                    ChoosedAngles = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                }
                else
                {
                    Debug.Log(sportName + ": " + result.Data[sportName]);
                    print("result split:" + result.Data[sportName].Split(new char[] { ',' }).Select(Int32.Parse).ToList());
                    ChoosedAngles = result.Data[sportName].Split(new char[] { ',' }).Select(Int32.Parse).ToList();
                }
            },
            error => {
                ChoosedAngles = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                Debug.Log("Got error getting titleData:");
                Debug.Log(error.GenerateErrorReport());
            }
        );
    }
    public static bool isAllChoosedDetected()
    {
        for (int i = 0; i < 10; i++)
        {
            if (ChoosedAngles.Contains(i))
            {
                if (EvaluateAngle.PointScore[i,0] == 0) return false;
            }

        }
        return true;
    }

    private void OnDestroy()
    {
        
    }


    

}
