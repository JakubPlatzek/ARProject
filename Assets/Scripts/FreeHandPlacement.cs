using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

public class FreeHandPlacement : MonoBehaviour
{
    public FixedJoystick LeftJoystick;
    public FixedJoystick RightJoystick;
    public GameObject PlaceLayoutButton;
    public float moveSpeed = 1f;
    private Vector3 questPosition;
    public ARRaycastManager raycastManager;
    private Object quest;
    private bool pressed = false;
    
    private void Start()
    {
        LeftJoystick.gameObject.SetActive(true);
        RightJoystick.gameObject.SetActive(true);
        PlaceLayoutButton.gameObject.SetActive(true);
        PlaceLayoutButton.GetComponent<Button>().onClick.AddListener(placeLayoutPressed);
    }

    public void Update()
    {
        if (pressed && !quest)
        {
            pressed = false;
            InstantiateQuestResource();
        }
        Reposition();
    }

    void Reposition()
    {
        if (quest)
        {
            float moveX = LeftJoystick.Horizontal;
            float moveZ = LeftJoystick.Vertical;
            Vector3 moveVector = new Vector3(moveX, 0, moveZ) * (moveSpeed * Time.deltaTime);
            quest.GameObject().transform.Translate(moveVector, Space.World);

            float rotateY = RightJoystick.Horizontal;
            Vector3 rotateVector = new Vector3(0, rotateY, 0) * (moveSpeed * Time.deltaTime * 100);
            quest.GameObject().transform.Rotate(rotateVector, Space.World);
        }
    }


    private void placeLayoutPressed()
    {
        pressed = true;
    }

    void InstantiateQuestResource()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if (raycastManager.Raycast(new Vector2(0.5f, 0.5f), hits, TrackableType.Planes))
        {
            ARRaycastHit hit = hits[0];
            questPosition = hit.pose.position;
            quest = Instantiate(Resources.Load("Quest 1"), questPosition, hit.pose.rotation);
            PlaceLayoutButton.SetActive(false);
        }
        else
        {
            Debug.Log("Could not find feature points");   
        }
    }
}