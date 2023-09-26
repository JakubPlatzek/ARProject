using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ExitManualModeHandler : MonoBehaviour
{
    public GameObject ManualMode;
    public ARPointCloudManager ARPointCloudManager;
    public ManualPlacement manualPlacement;

    public GameObject MainMenuButton;


    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton.SetActive(false);
    }

    public void ExitManualMode(){
        MainMenuButton.SetActive(true);
        ManualMode.SetActive(false);
        ARPointCloudManager.enabled = false;
        manualPlacement.tableCorners = new List<Vector3>();
    }
}
