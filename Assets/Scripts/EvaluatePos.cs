using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OpenPose.Example
{
    public class EvaluatePos : MonoBehaviour
    {
        public static Text ScoreText;
        public Transform refTarget;
        public static Transform standardModelTarget;
        private void Awake()
        {
            //ScoreText = GameObject.Find("Score").GetComponent<Text>();
            //standardModelTarget = GameObject.Find("mannequiny-0.4.0").transform.Find("1");  //find standard model's neck
            //standardModelTarget = refTarget;
            /*
            foreach (var child in Unitychan.GetComponentsInChildren<SkinnedMeshRenderer>())
            {
                child.material.color = new Color(1f, 1f, 1f, 0.1f);
            }
            foreach (var child in Unitychan.GetComponentsInChildren<MeshRenderer>())
            {
                child.material.color = new Color(1f, 1f, 1f, 0.5f);
            }
            */
        }
        // Start is called before the first frame update
        /*
        public static void eval_pos_sync(Vector3 pos)
        {
            // Clearer
            //Vector3 refPos = UnityEditor.Handles.GetMainGameViewSize()/2 - (Vector2)standardModel.transform.position;
            // Verbose, but probably faster
            Vector3 refPos = new Vector3(UnityEditor.Handles.GetMainGameViewSize().x/2 - standardModelTarget.transform.position.x, UnityEditor.Handles.GetMainGameViewSize().y/2 - standardModelTarget.transform.position.y, 0f);
            //print("mine:" + pos.x + "," + pos.y +standardModel.name + refPos.x + ", " + refPos.y);
            ScoreText.text = Vector3.Distance(pos, refPos).ToString();
        }*/
        
    }
}

