using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ManualPlacement : MonoBehaviour
{
    public ARRaycastManager m_RaycastManager;
    public GameObject collectedPosition;
    public List<Vector3> tableCorners = new List<Vector3>();
    public bool pressed = false;
    public bool canPress = true;
    public Camera ARCamera;
    public SelectQuestHandler selectQuestHandler;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    Vector3 evaluatedPosition = new Vector3();
    Vector3 evaluatedRotation = new Vector3();

    public void CollectPosition(){
        pressed = true;
    }

    void Update(){
        if(pressed && canPress){
            if(m_RaycastManager.Raycast(ARCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), m_Hits, TrackableType.FeaturePoint)){
                Instantiate(collectedPosition, m_Hits[0].pose.position, m_Hits[0].pose.rotation);
                tableCorners.Add(m_Hits[0].pose.position);
                if(tableCorners.Count == 3){
                    EvaluateCollection();
                    PositionChosenQuestLayout();
                    GetComponent<Button>().interactable = false;
                }
                else{
                    BlockPress();
                }
            }
        }
    }

    void BlockPress(){
        pressed = false;
        canPress = false;
        Invoke("UnblockPress", 1f);
    }

    void UnblockPress(){
        canPress = true;
    }

    void EvaluateCollection(){
        Vector3 vectorAtoB = tableCorners[0] - tableCorners[1];
        Vector3 vectorAtoC = tableCorners[2] - tableCorners[1];
        evaluatedPosition = tableCorners[1] + vectorAtoB * 0.5f + vectorAtoC * 0.5f;
        float averageHeight = (tableCorners[0].y + tableCorners[1].y + tableCorners[2].y) / 3;
        evaluatedPosition.y = averageHeight;
        evaluatedRotation = vectorAtoB;
    }

    void PositionChosenQuestLayout(){
        Instantiate(Resources.Load("Quest 1"), evaluatedPosition, Quaternion.LookRotation(evaluatedRotation));
    }
}
