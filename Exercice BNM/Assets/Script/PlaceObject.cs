using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class PlaceObject : MonoBehaviour
{

    public GameObject presse;

    private GameObject ThePresse;
    private ARRaycastManager raycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryPositionTouch(out Vector2 positionTouch)
    {
        if(Input.touchCount == 1)
        {
            positionTouch = Input.GetTouch(0).position;
            return true;
        }

        positionTouch = default;
        return false;
    }

    void Update()
    {
        if(!TryPositionTouch(out Vector2 positionTouch))
        {
            return;
        }

        if(raycastManager.Raycast(positionTouch, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            if(ThePresse == null)
            {
                ThePresse = Instantiate(presse, hitPose.position, hitPose.rotation);
            }
            else
            {
                ThePresse.transform.position = hitPose.position;
            }
        }
    }
}
