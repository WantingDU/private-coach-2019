using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModelToBody25 : MonoBehaviour
{
    //--------------------- PILS ------------------------------//
    public List<Transform> poseStandard;
    public GameObject ball;
    private GameObject[] Myballs= new GameObject[10];
    private MeshRenderer[] renderballs= new MeshRenderer[10];
    private int globalCounter;
    public int[,] errorCounter = new int[10, 100];
    public int[,] moyPointScore = new int[10, 2]; //pour chaque point : [sum, moy]
    public int[] written = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public string errorMessage;
    public static string[,] advices = {{"bassez votre bras droit ", "levez votre bras droit"},
                                        {"écartez votre bras droit", "serrez votre bras droit"},
                                        {"bassez votre bras gauche ", "levez votre bras gauche" },
                                        {"écartez votre bras gauche", "serrez votre bras gauche" },
                                        {"penchez vers la gauche","penchez vers la droite"},{"penchez vers la droite","penchez vers la gauche"},
                                        {"serrez votre cuisse droite", "ecartez votre cuisse droite"},
                                        {"pliez votre genoux droit", "pliez votre genoux gauche"},
                                        {"serrez votre cuisse gauche", "ecartez votre cuisse gauche"},
                                        {"pliez votre genoux gauche", "pliez votre genoux gauche"}};
    //--------------------- PILS ------------------------------/
    private void Awake()
    {
        ball = Resources.Load<GameObject>("Sphere") as GameObject;
        for (int i = 0; i < 10; i++)
        {
                Myballs[i]=Instantiate(ball, poseStandard[EvaluateAngle.OP_anglePoints[i, 1]].transform);
                Myballs[i].tag = "boules";
                renderballs[i] = Myballs[i].GetComponent<MeshRenderer>();
                renderballs[i].enabled = false;
        }
        
    }
    private int ratioCol(int[,] tab, int col)
    {
        //retourne un pourcentage (entier)
        int sum = 0;
        for (int i = 0; i < tab.GetLength(1); i++)
        {
            sum += tab[col, i];
        }
        UnityEngine.Debug.Log("RATIO : " + sum.ToString() + "   COL : " + col.ToString());
        return sum;
    }

    private void Update()
    {
        bool there_is_an_error = false;
        globalCounter += 1;
        for (int i = 0; i < 10; i++) {
            //When the joint is not choosed
            if (!StaticItems.ChoosedAngles.Contains(i))
            {
                renderballs[i].enabled = false;
                EvaluateAngle.PointScore[i,0] = 0;
            }
            //when the joint is not detected
            else if (EvaluateAngle.PointScore[i,0] == 0)
            {
                renderballs[i].enabled = true;
                renderballs[i].material.color = Color.gray;
            }
            else if (EvaluateAngle.PointScore[i,0] < 0.7)
            {
                moyPointScore[i, 0] += 1;
                moyPointScore[i, 1] = (int)((100 * moyPointScore[i, 0]) / globalCounter);
                there_is_an_error = true;
                errorCounter[i, globalCounter % errorCounter.GetLength(1)] = 1;
                //mise à jour affichage
                if (globalCounter % 40 == 0)
                {
                    UnityEngine.Debug.Log(moyPointScore[i, 1]);
                    if (ratioCol(errorCounter, i) > 50)
                    {       //>50%
                        UnityEngine.Debug.Log("in ERROR");
                        if (written[i] == 0)
                        { //affectation du niveau de priorité
                            written[i] = i + 1;
                        }
                        if (written.Max() == written[i])
                        { //vérification de la priorité
                           errorMessage = advices[i, (int)EvaluateAngle.PointScore[i, 1]];
                            UnityEngine.Debug.Log(EvaluateAngle.PointScore[i, 1].ToString());

                            //update stat
                            //StaticItems.AdviseText.gameObject.SetActive(true);
                            StaticItems.ErrorMessage = advices[i, (int)EvaluateAngle.PointScore[i, 1]];
                            //StaticItems.AdviseText.text = errorMessage;
                            //StaticItems.ErrorTime = DateTime.Now.ToString();
                        }
                    }
                }


                renderballs[i].enabled = true;
                if (EvaluateAngle.PointScore[i, 1] == 1) // angle trop grand -> rouge
                    renderballs[i].material.color = new Color(1 - EvaluateAngle.PointScore[i, 0], 0, 0, 1);
                else
                    renderballs[i].material.color = new Color(0, 0, 1 - EvaluateAngle.PointScore[i, 0], 1);
            }
        
            //When joint with good angle
            else
            {
                errorCounter[i, globalCounter % errorCounter.GetLength(1)] = 0;
                renderballs[i].enabled = false;
                written[i] = 0;
            }
            if (there_is_an_error == false)
            {
               errorMessage = "";
            }
        }
    } 

    
}
