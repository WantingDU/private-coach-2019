using UnityEngine;
using UnityEngine.UI;

public class AutoHelpTextCoach : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = "* Appuyez sur start pour démarrer, vous aurez 3 secondes" +
                                                  "\n* L’exercice ne commence pas tant que toutes les articulations nécéssaires pour le sport ne sont pas  visibles" +
                                                  "\n* Faitez bouger la molette en bas pour faire varier la vitesse " +
                                                  "\n* Appuyez sur le menu en haut à droite pour cacher la image de fond si vous voulez" +
                                                  "\n* Glissez l’écran vers la droite, vous verrez vos statistiques";
    }
}
