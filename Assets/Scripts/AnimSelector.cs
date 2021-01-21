using Lean.Gui;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimSelector : MonoBehaviour
{
    public void onClickAnim()
    {
        StaticItems.AnimName = this.transform.name;
        GameObject.Find("Left Box").GetComponent<LeanSnap>().SnapWrapper(350f);
    }
    //change to the choosed anim and start the anim, then swipe to the second screen automatically
    public void onStartSport()
    {
        RuntimeAnimatorController choosedAnim = Resources.Load("Anim/AnimController/" + StaticItems.AnimName) as RuntimeAnimatorController;
        //check which joints to evaluate from Playfab database
        if (PlayFabClientAPI.IsClientLoggedIn())
        {
            try
            {
                StaticItems.ClientGetTitleData(StaticItems.AnimName);
            }
            finally
            {
                Debug.Log("finished");
            }
        }
        //if not login, assum evaluate default joints
        else
        {
            StaticItems.ChoosedAngles = StaticItems.ChoosedAngles_default;
        }

        StaticItems.Coach.GetComponent<Animator>().runtimeAnimatorController = choosedAnim;
        GameObject.Find("Screens").GetComponent<LeanSnap>().SnapWrapper(-1000f);
        GameObject.Find("LeanWindowCloser").GetComponent<LeanWindowCloser>().CloseAll();
    }
    public void onClickDemo()
    {

    }
}
