using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixScreen : MonoBehaviour
{
    // Start is called before the first frame update
    LeanDrag drag;
    
    void Start()
    {
        drag=GameObject.Find("Screens").GetComponent<LeanDrag>();
        drag.enabled = true;
    }

    // Update is called once per frame
    public void onSwitch2Fix()
    {
        drag.enabled = !this.GetComponent<LeanToggle>().On;
    }
}
