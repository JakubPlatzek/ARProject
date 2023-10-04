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
    private GameObject thisGameObject;
    
    private Dictionary<string, string> descriptions = new Dictionary<string, string>()
    {
        {"Tile", "The Black Plague tiles create a rich and intricate medieval town. Street zones don’t spread across multiple tiles, creating lots of twisting alleys for you to try and evade the oncoming undead. And if you find one of the secret vaults, you may be able to cross the entire map a lot faster (and you may even find a couple of very powerful artifacts down there)."},
        {"Tile Purple Vault", "Tile"},
        {"Tile Yellow Vault", "Tile"},
        {"Door blue", "blue door"},
        {"Door green", "blue green"},
        {"Door red", "blue red"},
        {"Exit", "Exit"},
        {"Objective blue", "blue objective"},
        {"Objective red", "red objective"},
        {"Objective green", "green objective"},
        {"Spawn blue", "blue Spawn"},
        {"Spawn red", "red Spawn"},
        {"Spawn green", "green Spawn"},
        {"Starting area", "green Spawn"},
        {"Vault door purple", "purple Spawn"},
        {"Vault door yellow", "yellow Spawn"},
    };

    private void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        thisGameObject = gameObject;
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
                    if (raycastHit.transform == transform) 
                    {
                        string objectName = thisGameObject.name;
                        
                        if (objectName.Contains("Quest"))
                        {
                            objectName = "Tile";
                        }
                        
                        if (descriptions.TryGetValue(objectName, out string description))
                        {
                            CreateDescription(description);
                        }
                        
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
        const float DEFAULT_POS_ABOVE = 0.25f;
        const float REDUCED_POS_ABOVE = 0.2f;
        const float REDUCED_SCALE = 1f;
        
        if (isPopupActive && currentPopupInstance != null)
        {
            Destroy(currentPopupInstance);
            isPopupActive = false;
            return;
        }
        
        float posAbove = text.Contains("tiles") ? DEFAULT_POS_ABOVE : REDUCED_POS_ABOVE;
        Vector3 popupPosition = transform.position + Vector3.up * (transform.localScale.y / 2 + posAbove); // Position above the cube
        currentPopupInstance = Instantiate(popupTextPrefab, popupPosition, Quaternion.identity);

        if (!text.Contains("tiles"))
        {
            Console.WriteLine("reducing");
            currentPopupInstance.transform.localScale *= REDUCED_SCALE; 
        }
        
        TextMeshPro textComponent = currentPopupInstance.transform.GetChild(1).GetComponent<TextMeshPro>();
        textComponent.text = text;
        isPopupActive = true;
        
    }
}
