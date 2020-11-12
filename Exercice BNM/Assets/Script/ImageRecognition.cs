using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageRecognition : MonoBehaviour
{
    GameObject pupitre;
    GameObject canvas;

    void Update()
    {
        //Récupère l'objet pupitre et si il l'a déjà, lui donne la bonne taille et rotation
        if(pupitre == null)
        {
            pupitre = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            pupitre.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            pupitre.transform.rotation = Quaternion.Euler(-90, -90, 0);
        }

        //Au touche de l'utilisateur, affiche ou non les information de la carte de visite
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    canvas = pupitre.transform.Find("Canvas").gameObject;
                    if (canvas.activeSelf)
                    {
                        canvas.SetActive(false);
                    }
                    else
                    {
                        canvas.SetActive(true);
                    }
                    
                }
            }

        }
    }
}
