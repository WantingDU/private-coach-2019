using UnityEngine;
using UnityEngine.UI;

public class AutoHelpText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = "<size=60>Hello" + StaticItems.username+" !</size>" +
                                                  "\nSwipe the screen to change the screen" +
                                                  "\nPress or touch the outside area to close windows";
    }
}
