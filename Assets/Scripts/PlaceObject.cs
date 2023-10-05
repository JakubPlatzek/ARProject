using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObject : MonoBehaviour
{
    public GameObject clearButton;
    public GameObject freeHandMenu;
    GameObject _placedLayout;
    public GameObject placedLayout{ 
        get{
            return _placedLayout;
        } 
        set{
            _placedLayout = value;
            if(value != null && !freeHandMenu.activeSelf){
                clearButton.SetActive(true);
            }
            else{
                clearButton.SetActive(false);
            }
        } 
    }
    public string objectToPlace; 
    ARRaycastManager m_RaycastManager;

    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    void Start(){
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }
}
