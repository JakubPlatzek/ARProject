using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Linq;

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
    List<GameObject> collectionPrefabs = new List<GameObject>();
    Vector3 evaluatedPosition = new Vector3();
    Vector3 evaluatedRotation = new Vector3();

    public void CollectPosition(){
        pressed = true;
    }

    void Update(){
        if(pressed && canPress){
            if(m_RaycastManager.Raycast(ARCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), m_Hits, TrackableType.FeaturePoint)){
                GameObject collectionPrefab = Instantiate(collectedPosition, m_Hits[0].pose.position, m_Hits[0].pose.rotation);
                collectionPrefabs.Add(collectionPrefab);
                tableCorners.Add(m_Hits[0].pose.position);
                if(tableCorners.Count == 3){
                    EvaluateMeasuredPositions();
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
    /**
        Figure out biggest angle and set the belonging corner into the middle position of the list
    */
    void EvaluateMeasuredPositions(){
        float angle01 = Vector3.Angle(tableCorners[0] - tableCorners[1], tableCorners[2] - tableCorners[1]);
        float angle02 = Vector3.Angle(tableCorners[0] - tableCorners[2], tableCorners[1] - tableCorners[2]);
        float angle12 = Vector3.Angle(tableCorners[1] - tableCorners[0], tableCorners[2] - tableCorners[0]);
        float[] arrayOfAngles = {angle12, angle01, angle02};
        int index = arrayOfAngles.ToList().IndexOf(arrayOfAngles.Max());
        Vector3 tmp = tableCorners[1];
        tableCorners[1] = tableCorners[index];
        tableCorners[index] = tmp;
    }

    void PositionChosenQuestLayout(){
        Instantiate(Resources.Load(selectQuestHandler.placeObject.objectToPlace), evaluatedPosition, Quaternion.LookRotation(evaluatedRotation));
    }

    public void Reset(){
        tableCorners.Clear();
        pressed = false;
        canPress = true;
        GetComponent<Button>().interactable = true;
        foreach(GameObject collectionPrefab in collectionPrefabs){
            Destroy(collectionPrefab);
        }
    }
}
