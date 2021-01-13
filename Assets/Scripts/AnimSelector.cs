using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimSelector : MonoBehaviour
{
    public void onClickAnim()
    {
        StaticItems.AnimName = this.transform.name;
        print(StaticItems.AnimName);

    }
    //change to the choosed anim and start the anim, then swipe to the second screen automatically
    public void onStartSport()
    {
        RuntimeAnimatorController choosedAnim = Resources.Load("Anim/AnimController/" + StaticItems.AnimName) as RuntimeAnimatorController;
        print(choosedAnim);
        try
        {
            StaticItems.ClientGetTitleData(StaticItems.AnimName);
        }
        finally
        {
            Debug.Log("finished");
        }
        StaticItems.Coach.GetComponent<Animator>().runtimeAnimatorController = choosedAnim;
        GameObject.Find("Screens").GetComponent<LeanSnap>().SnapWrapper();
        GameObject.Find("LeanWindowCloser").GetComponent<LeanWindowCloser>().CloseAll();
    }
    public void onClickDemo()
    {

    }
}
