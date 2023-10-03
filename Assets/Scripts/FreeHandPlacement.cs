using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

enum FreeHandState
{
    placeObject,
    destroyObject
}

public class FreeHandPlacement : MonoBehaviour
{
    public FixedJoystick LeftJoystick;
    public FixedJoystick RightJoystick;
    public GameObject RedButton;
    public float moveSpeed = 1f;
    public SelectQuestHandler selectQuestHandler;
    private Vector3 questPosition;
    public ARRaycastManager raycastManager;
    private Object quest;
    private bool createQuest = false;
    private FreeHandState state = FreeHandState.placeObject;
    public GameObject ExitButton;
    public Text ButtonText;
    private void Start()
    {
        LeftJoystick.gameObject.SetActive(true);
        RightJoystick.gameObject.SetActive(true);
        RedButton.gameObject.SetActive(true);
        ExitButton.SetActive(false);
        RedButton.GetComponent<Button>().onClick.AddListener(buttonPressed);
    }

    public void Update()
    {
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


    private void buttonPressed()
    {
        if (state == FreeHandState.destroyObject)
        {
            Destroy(quest.GameObject());
            quest = null;
            RedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Place \n Layout";
            ExitButton.SetActive(false);
            state = FreeHandState.placeObject;
        }
        else if (state == FreeHandState.placeObject) {
            InstantiateQuestResource();
            RedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Remove \n Layout";
            ExitButton.SetActive(true);
            state = FreeHandState.destroyObject;
        }
    }

    void InstantiateQuestResource()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if (raycastManager.Raycast(new Vector2(0.5f, 0.5f), hits, TrackableType.Planes))
        {
            ARRaycastHit hit = hits[0];
            questPosition = hit.pose.position;
            quest = Instantiate(Resources.Load(selectQuestHandler.placeObject.objectToPlace), questPosition, hit.pose.rotation);
        }
        else
        {
            Debug.Log("Could not find feature points");   
        }
    }
}