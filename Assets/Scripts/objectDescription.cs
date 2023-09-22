using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class objectDescription : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public GameObject popupTextPrefab;
    private GameObject currentPopupInstance;
    private bool isPopupActive = false;

    private void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
        
            if (touch.phase == TouchPhase.Began && raycastManager.Raycast(touch.position, hits))
            {
                RaycastHit raycastHit;
                if (Physics.Raycast(hits[0].pose.position, Vector3.forward, out raycastHit))
                {
                    if (raycastHit.transform == transform) // If the cube was clicked
                    {
                        CreateDescription("test cube");
                    }
                }
            }
        }
    }
    

    private void CreateDescription(string text)
    {
        
        if (isPopupActive  && currentPopupInstance != null)
        {
            Destroy(currentPopupInstance);
            isPopupActive = false;
            return;
        }
        
        
        Vector3 popupPosition = transform.position + Vector3.up * (transform.localScale.y / 2 + 0.4f); // Position above the cube
        currentPopupInstance = Instantiate(popupTextPrefab, popupPosition, Quaternion.identity);
        
        TextMeshPro textComponent = currentPopupInstance.transform.GetChild(1).GetComponent<TextMeshPro>();
        textComponent.text = text;
        isPopupActive = true;

    }
}
