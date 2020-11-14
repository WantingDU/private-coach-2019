using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimSpeedController : MonoBehaviour
{
    [SerializeField] float animSpeedControl = 1f;
    [SerializeField] Animator mainAnimator;
    Slider Slider;
    private void Start()
    {
        Slider=GameObject.Find("Slider").GetComponent<Slider>();
    }
    // Start is called before the first frame update
    public void onChangeSpeed()
    {
        animSpeedControl = Slider.value;
        mainAnimator.SetFloat("speed", animSpeedControl);
    }
}
