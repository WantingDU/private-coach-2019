using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigSports : MonoBehaviour
{

    public void selectDifficulty()
    {
        StaticItems.difficulty = this.gameObject.name;
        switch (StaticItems.difficulty)
        {
            case "Easy":
                StaticItems.eval_standard = 0.7f;
                break;
            case "Middle":
                StaticItems.eval_standard = 0.8f;
                break;
            case "Expert":
                StaticItems.eval_standard = 0.9f;
                break;
        }
    }
}
