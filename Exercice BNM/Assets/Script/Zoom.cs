using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    private GameObject ThePresse = null;
    public float zoomSpeed = 0.01f;
    private float minZoom = 0.01f;
    private float maxZoom = 0.5f;

    void Update()
    {
        //Recuperation de l'objet
        if(ThePresse == null)
        {
            ThePresse = GameObject.FindGameObjectWithTag("Player");
        }
        //Si deux doigt touche l'écran et que l'objet est récupérer on calcul la magnitude du mouvment des 2 doigt
        if (Input.touchCount == 2 && ThePresse != null)
        {
            Touch touche0 = Input.GetTouch(0);
            Touch touche1 = Input.GetTouch(1);

            Vector2 touch0PrevPos = touche0.position - touche0.deltaPosition;
            Vector2 touch1PrevPos = touche1.position - touche1.deltaPosition;

            float prevMagnitude = (touch0PrevPos - touch1PrevPos).magnitude;
            float currentMagnitude = (touche0.position - touche1.position).magnitude;

            float zoom = (touche0.deltaPosition - touche1.deltaPosition).magnitude*zoomSpeed;

            //On effectue le zoom entre 2 valeur donnée
            if (prevMagnitude > currentMagnitude)
            {
                ThePresse.transform.localScale = new Vector3(Mathf.Clamp(ThePresse.transform.localScale.x - zoom, minZoom, maxZoom), Mathf.Clamp(ThePresse.transform.localScale.y - zoom, minZoom, maxZoom), Mathf.Clamp(ThePresse.transform.localScale.z - zoom, minZoom, maxZoom));
            }
            if (prevMagnitude < currentMagnitude)
            {
                ThePresse.transform.localScale = new Vector3(Mathf.Clamp(ThePresse.transform.localScale.x + zoom, minZoom, maxZoom), Mathf.Clamp(ThePresse.transform.localScale.y + zoom, minZoom, maxZoom), Mathf.Clamp(ThePresse.transform.localScale.z + zoom, minZoom, maxZoom)); ;
            }

        }
    }
}
