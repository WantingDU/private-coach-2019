using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



    public class EvaluateAngle : MonoBehaviour
    {
        public static Text ScoreText;
        public static int[,] OP_anglePoints = new int[,] { {1, 2, 3}, // 0 Right shoulder
                                                            {2, 3, 4}, // 1 Right elbow
                                                            {1, 5, 6}, // 2 left shoulder
                                                            {5, 6, 7}, // 3 Left elbow
                                                            {1, 8, 9}, // 4 Bust 1 (right)
                                                            {1, 8, 12}, // 5 Bust 2 (left)
                                                            {8, 9, 10}, // 6 Hips right
                                                            {8, 12, 13}, // 7 Hips left
                                                            {9, 10, 11}, // 8 Knee right
                                                            {12, 13, 14} // 9 Knee left
                                                        };
        private static float[] OP_Cos = new float[10];
        private static float[] OP_Sin = new float[10];
        private static float[] Ref_Cos = new float[10];
        private static float[] Ref_Sin = new float[10];
        public static float[] PointScore = new float[10];
        private void Awake()
        {
            //Clear all static data
            OP_Cos = new float[10];
            OP_Sin = new float[10];
            Ref_Cos = new float[10];
            Ref_Sin = new float[10];
            PointScore = new float[10];
            ScoreText = GameObject.Find("Score").GetComponent<Text>();
        }

        public static float ComputeCos(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            Vector3 vec1 = p1 - p2;
            Vector3 vec2 = p3 - p2;
            float angleCos = Vector3.Dot(vec1.normalized, vec2.normalized);
            return angleCos;
        }

        public static float ComputeSin(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            Vector3 vec1 = p1 - p2;
            Vector3 vec2 = p3 - p2;
            Vector3 crossProduct = Vector3.Cross(vec1.normalized, vec2.normalized);
            float angleSin = Vector3.Magnitude(crossProduct) * Mathf.Sign(crossProduct.z);
            return angleSin;
        }

        public static void Compute_OP_PseudoAngle(List<RectTransform> poseJoints)
        {
             for(int i = 0; i < 10; i++)
             {
                RectTransform joint1 = poseJoints[OP_anglePoints[i,0]];
                RectTransform joint2 = poseJoints[OP_anglePoints[i,1]];
                RectTransform joint3 = poseJoints[OP_anglePoints[i,2]];
                if ((joint1.gameObject.activeSelf) && (joint2.gameObject.activeSelf) && (joint3.gameObject.activeSelf))
                {
                    OP_Cos[i] = ComputeCos(joint1.localPosition, joint2.localPosition, joint3.localPosition);
                    OP_Sin[i] = ComputeSin(joint1.localPosition, joint2.localPosition, joint3.localPosition);
                }
                else
                {
                    OP_Cos[i] = 0;
                    OP_Sin[i] = 0;
                }
             }
             //print("left elbow cos: " + OP_Cos[3]);
             //print("left elbow sin: " + OP_Sin[3]);
             //print("left elbow angle: " + Mathf.Sign(OP_Sin[3]) * Mathf.Acos(OP_Cos[3]) * 57.29578f);
        }
        public static void Compute_Model_PseudoAngle(List<Transform> poseJoints)
        {
            for (int i = 0; i < 10; i++)
            {
                Transform joint1 = poseJoints[OP_anglePoints[i, 0]];
                Transform joint2 = poseJoints[OP_anglePoints[i, 1]];
                Transform joint3 = poseJoints[OP_anglePoints[i, 2]];
                if ((joint1.gameObject.activeSelf) && (joint2.gameObject.activeSelf) && (joint3.gameObject.activeSelf))
                {
                    Ref_Cos[i] = ComputeCos(new Vector3(joint1.position.x,joint1.position.y,0f), new Vector3(joint2.position.x, joint2.position.y, 0f), new Vector3(joint3.position.x, joint3.position.y, 0f));
                    Ref_Sin[i] = ComputeSin(new Vector3(joint1.position.x, joint1.position.y, 0f), new Vector3(joint2.position.x, joint2.position.y, 0f), new Vector3(joint3.position.x, joint3.position.y, 0f));
            }
                else
                {
                    Ref_Cos[i] = 0;
                    Ref_Sin[i] = 0;
                }
            }
            //print("left elbow cos: " + OP_Cos[3]);
            //print("left elbow sin: " + OP_Sin[3]);
    
            //print("left elbow angle standard: " + Mathf.Sign(OP_Sin[3]) * Mathf.Acos(OP_Cos[3]) * 57.29578f);
        }

        public static float ComputeScore()
        {
            float score = 0f;
            int n = 0;
            for (int i = 0; i < 10; i++)
            {
                if (!((OP_Cos[i]==0) && (OP_Sin[i]==0)))
                {
                    PointScore[i] = (1 - Mathf.Abs((OP_Cos[i] - Ref_Cos[i] + OP_Sin[i] - Ref_Sin[i]) / 2f));
                    score += PointScore[i];
                    n += 1;
            }
                else
                    {
                        PointScore[i] = 0;
                    }
            }

            if(n!=0)
            ScoreText.text = (100f * (score/n)).ToString("F0")+'%';
            return score;
        }

    }


