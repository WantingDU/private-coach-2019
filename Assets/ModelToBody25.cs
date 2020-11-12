using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelToBody25 : MonoBehaviour
{
    //--------------------- PILS ------------------------------//
    public List<Transform> poseStandard;
    public GameObject ball;
    private GameObject[] Myballs= new GameObject[10];
    private MeshRenderer[] renderballs= new MeshRenderer[10];
    //--------------------- PILS ------------------------------/
    private void Awake()
    {
        ball = Resources.Load<GameObject>("Sphere") as GameObject;
        for (int i = 0; i < 10; i++)
        {
                Myballs[i]=Instantiate(ball, poseStandard[EvaluateAngle.OP_anglePoints[i, 1]].transform);
                renderballs[i] = Myballs[i].GetComponent<MeshRenderer>();
                renderballs[i].enabled = false;
        }
        
    }
    
    private void Update()
    {
        for (int i = 0; i < 10; i++) {
            if (EvaluateAngle.PointScore[i] == 0)
            {
                renderballs[i].enabled = true;
                renderballs[i].material.color = Color.gray;
            }
            else if (EvaluateAngle.PointScore[i] < 0.7)
            {
                renderballs[i].enabled = true;
                renderballs[i].material.color = new Color(1 - EvaluateAngle.PointScore[i], 0, 0, 1);
            }
            else
            {
                renderballs[i].enabled = false;
            }   
        } 

    }
}
