using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ExitManualModeHandler : MonoBehaviour
{
    public GameObject PlacementMode;
    public ARPointCloudManager ARPointCloudManager;
    public ARPlaneManager ARPlaneManager;
    public ManualPlacement manualPlacement;
    public GameObject MainMenuButton;


    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton.SetActive(false);
    }

    public void ExitManualMode(){
        PlacementMode.SetActive(false);
        MainMenuButton.SetActive(true);
        ARPointCloudManager.enabled = false;
        ARPlaneManager.enabled = false;
        if (manualPlacement)
        {
            manualPlacement.tableCorners = new List<Vector3>();   
        }
    }
}
