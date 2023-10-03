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
}
