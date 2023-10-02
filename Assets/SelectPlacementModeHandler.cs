using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SelectPlacementModeHandler : MonoBehaviour
{
    public ARPointCloudManager ARPointCloudManager;
    public ARPlaneManager ARPlaneManager;
    public GameObject ManualMode;
    public GameObject PlacementModeMenu;
    public GameObject FreeHandPlacement;

    public void SelectSpawnMode(){
        if(gameObject.name.Equals("Free hand mode")){
            FreeHandPlacement.SetActive(true);
            ARPointCloudManager.enabled = false;
            ARPlaneManager.enabled = true;
        } else {
            ARPointCloudManager.enabled = true;
            ARPlaneManager.enabled = false;
            ManualMode.SetActive(true);
        }
        PlacementModeMenu.SetActive(false);
    }
}
