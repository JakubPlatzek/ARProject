using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObject : MonoBehaviour
{
    public string objectToPlace;
    ARRaycastManager m_RaycastManager;

    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    void Start(){
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if(objectToPlace.Length > 0){
            if (Input.touchCount > 0){
                if(m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits, TrackableType.PlaneWithinPolygon)){
                    Instantiate(Resources.Load(objectToPlace), m_Hits[0].pose.position, m_Hits[0].pose.rotation);
                }
            }
        }
    }

}
