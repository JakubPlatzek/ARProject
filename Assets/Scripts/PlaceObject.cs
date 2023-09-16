using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObject : MonoBehaviour
{
    public GameObject objectToPlace;
    ARRaycastManager m_RaycastManager;

    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    void Start(){
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0){
            if(m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits, TrackableType.PlaneWithinPolygon)){
                Instantiate(objectToPlace, m_Hits[0].pose.position, m_Hits[0].pose.rotation);
            }
        }
    }

}
