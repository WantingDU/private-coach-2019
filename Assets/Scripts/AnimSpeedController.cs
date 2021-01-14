using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimSpeedController : MonoBehaviour
{
    [SerializeField] float animSpeedControl = 1f;
    [SerializeField] List<Animator> mainAnimator;
    Slider Slider;
    float choosedSpeed;
    public static bool started;
    private void Start()
    {
        started = false;
        Slider = GameObject.Find("Slider").GetComponent<Slider>();
        foreach (Animator _animator in mainAnimator)
        {
            _animator.SetFloat("speed", animSpeedControl);
        }
    }

    public void onChangeSpeed()
    {
        animSpeedControl = Slider.value;
        foreach (Animator _animator in mainAnimator)
        {
            _animator.SetFloat("speed", animSpeedControl);
        }

    }
    public void onClickStart()
    {
        if (!started)
        {
            //StaticItems.Delay(3000);
            StartCoroutine(executeWait());

        }
        else
        {
            choosedSpeed = Slider.value;
            Slider.value = 0;
            started = !started;
        }
        
    }
    IEnumerator executeWait()
    {
       
        StaticItems.CountDown.gameObject.SetActive(true);
        StaticItems.CountDown.text = "3";
        yield return new WaitForSeconds(1);
        StaticItems.CountDown.text = "2";
        yield return new WaitForSeconds(1);
        StaticItems.CountDown.text = "1";
        yield return new WaitForSeconds(1);
        StaticItems.CountDown.text = "Start";
        //yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(()=>StaticItems.isAllChoosedDetected());
        StaticItems.CountDown.text = "";
        StaticItems.CountDown.gameObject.SetActive(false);
        // reset score recorder and start animation
        foreach (Animator _animator in mainAnimator)
        {
            _animator.Rebind();
            if (Slider.value == 0)
                Slider.value = 1.0f;
            if(choosedSpeed!=0)
                Slider.value = choosedSpeed;
                onChangeSpeed();
            EvaluateAngle.average = 0;
            EvaluateAngle.counter = 0;
            EvaluateAngle.sumScore = 0;
        }

        started = !started;
    }

  
        

    


}
