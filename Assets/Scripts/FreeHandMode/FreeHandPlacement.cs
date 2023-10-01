using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Object = UnityEngine.Object;

public class FreeHandPlacement : MonoBehaviour
{
    public FixedJoystick LeftJoystick;
    public FixedJoystick RightJoystick;
    public PlaceLayoutButton PlaceLayoutButton;
    public float moveSpeed = 1f;
    private Vector3 questPosition;
    public ARRaycastManager raycastManager;
    private Object quest;
    
    private void Start()
    {
        LeftJoystick.gameObject.SetActive(true);
        RightJoystick.gameObject.SetActive(true);
        PlaceLayoutButton.gameObject.SetActive(true);
    }

    public void Update()
    {
        if (PlaceLayoutButton.pressed && !quest)
        {
            InstantiateQuestResource();
        }
        Reposition();
    }

    void Reposition()
    {
        
    }
    
    void InstantiateQuestResource()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if (raycastManager.Raycast(new Vector2(0.5f, 0.5f), hits, TrackableType.PlaneWithinPolygon))
        {
            ARRaycastHit hit = hits[0];
            questPosition = hit.pose.position;
            quest = Instantiate(Resources.Load("Quest 1"), questPosition, hit.pose.rotation);
        }
    }
}