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
                Vector3 rayOrigin = Camera.main.transform.position;
                Vector3 rayDirection = hits[0].pose.position - rayOrigin;
                if (Physics.Raycast(rayOrigin, rayDirection.normalized, out raycastHit))
                {
                    if (raycastHit.transform == transform) // If the cube was clicked
                    {
                        CreateDescription("test cube");
                    }
                }
            }
        }
        
        if (isPopupActive && currentPopupInstance != null)
        {
            Vector3 directionToCamera = currentPopupInstance.transform.position - Camera.main.transform.position;
            directionToCamera.y = 0;  // This nullifies the vertical difference
            currentPopupInstance.transform.rotation = Quaternion.LookRotation(directionToCamera);
        }
    }
    

    private void CreateDescription(string text)
    {
        
        if (isPopupActive && currentPopupInstance != null)
        {
            Destroy(currentPopupInstance);
            isPopupActive = false;
            return;
        }
        
        
        Vector3 popupPosition = transform.position + Vector3.up * (transform.localScale.y / 2 + 0.5f); // Position above the cube
        currentPopupInstance = Instantiate(popupTextPrefab, popupPosition, Quaternion.identity);

        TextMeshPro textComponent = currentPopupInstance.transform.GetChild(1).GetComponent<TextMeshPro>();
        textComponent.text = text;
        isPopupActive = true;
        
    }
}
