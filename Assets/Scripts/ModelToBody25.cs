using Lean.Gui;
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
    private int[,] errorCounter = new int[10, StaticItems.frameInterval];
    private int[,] moyPointScore = new int[10, 2]; //pour chaque point : [sum, moy]
    private int[] written = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    /*
    public static string[,] advices1 = {{"bassez votre bras droit ", "levez votre bras droit"},
                                        {"écartez votre bras droit", "serrez votre bras droit"},
                                        {"bassez votre bras gauche ", "levez votre bras gauche" },
                                        {"écartez votre bras gauche", "serrez votre bras gauche" },
                                        {"penchez vers la gauche","penchez vers la droite"},{"penchez vers la droite","penchez vers la gauche"},
                                        {"serrez votre cuisse droite", "ecartez votre cuisse droite"},
                                        {"pliez votre genoux droit", "pliez votre genoux gauche"},
                                        {"serrez votre cuisse gauche", "ecartez votre cuisse gauche"},
                                        {"pliez votre genoux gauche", "pliez votre genoux gauche"}};
    public static string[,] advices2 = {{"attention à votre épaule droit","attention à votre épaule droit"},
                                        {"attention à votre bras droit","attention à votre bras droit"},
                                        {"attention à  votre épaule gauche","attention à  votre épaule gauche" },
                                        {"attention à  votre bras gauche","attention à  votre bras gauche" },
                                        {"penchez vers la gauche","penchez vers la droite"},{"penchez vers la droite","penchez vers la gauche"},
                                        {"serrez votre cuisse droite", "ecartez votre cuisse droite"},
                                        {"pliez votre genoux droit", "pliez votre genoux gauche"},
                                        {"serrez votre cuisse gauche", "ecartez votre cuisse gauche"},
                                        {"pliez votre genoux gauche", "pliez votre genoux gauche"}};
    */
    public static string[,] advices = {{"Attention à votre épaule droite","Attention à votre épaule droite"},
                                        {"Attention à votre bras droit","Attention à votre bras droit"},
                                        {"Attention à votre épaule gauche","Attention à votre épaule gauche" },
                                        {"Attention à votre bras gauche","Attention à votre bras gauche" },
                                        {"Penchez vers la gauche","Penchez vers la droite"},{"Penchez vers la droite","Penchez vers la gauche"},
                                        {"Serrez votre cuisse droite", "Écartez votre cuisse droite"},
                                        {"Pliez votre genou droit", "Pliez votre genou gauche"},
                                        {"Serrez votre cuisse gauche", "Écartez votre cuisse gauche"},
                                        {"Pliez votre genou gauche", "Pliez votre genou gauche"}};
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
        //UnityEngine.Debug.Log("RATIO : " + sum.ToString() + "   COL : " + col.ToString());
        return sum;
    }

    private void Update()
    {
        if (!AnimSpeedController.clicked_start) return;
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
            else if (EvaluateAngle.PointScore[i,0] < StaticItems.eval_standard)
            {
                moyPointScore[i, 0] += 1;
                moyPointScore[i, 1] = (int)((StaticItems.frameInterval * moyPointScore[i, 0]) / globalCounter);
                errorCounter[i, globalCounter % errorCounter.GetLength(1)] = 1;
                //mise à jour affichage
                if (globalCounter % StaticItems.messageRate == 0)
                {
                    UnityEngine.Debug.Log(moyPointScore[i, 1]);
                    if (ratioCol(errorCounter, i) > 0.6*StaticItems.frameInterval)
                    {       //>60%
                        UnityEngine.Debug.Log(i+"in ERROR");
                        if (written[i] == 0)
                        { //affectation du niveau de priorité
                            written[i] = i + 1;
                        }
                        if (written.Max() == written[i])
                        { //vérification de la priorité
                            StaticItems.errorStatistics[i] += 1;
                            StaticItems.ErrorMessage = advices[i, (int)EvaluateAngle.PointScore[i, 1]];
                            StaticItems.AdviseText.text = StaticItems.ErrorMessage;
                            StaticItems.Notification.GetComponent<LeanPulse>().Pulse();
                        }
                    }
                    else
                    {
                        StaticItems.ErrorMessage = "";
                        StaticItems.AdviseText.text = StaticItems.ErrorMessage; 
                    }

                }



                renderballs[i].enabled = true;
                renderballs[i].material.color =Color.red;

            }
        
            //When joint with good angle
            else
            {
                errorCounter[i, globalCounter % errorCounter.GetLength(1)] = 0;
                renderballs[i].enabled = false;
                written[i] = 0;
            }

        }
    } 

    
}
