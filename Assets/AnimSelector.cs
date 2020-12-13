using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimSelector : MonoBehaviour
{
    public void onClickAnim()
    {
        string AnimName = this.GetComponentInChildren<Text>().text;
        print(AnimName);
        RuntimeAnimatorController choosedAnim = Resources.Load("Anim/AnimController/"+AnimName) as RuntimeAnimatorController;
        print(choosedAnim);
        StaticItems.Coach.GetComponent<Animator>().runtimeAnimatorController = choosedAnim;
    }
}
