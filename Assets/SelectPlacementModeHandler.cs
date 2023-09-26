using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SelectPlacementModeHandler : MonoBehaviour
{
    public ARPointCloudManager ARPointCloudManager;
    public ARPlaneManager ARPlaneManager;

    public void SelectSpawnMode(){
        if(this.gameObject.name.Equals("Free hand mode")){
            ARPointCloudManager.enabled = false;
            ARPlaneManager.enabled = true;
        }else{
            ARPointCloudManager.enabled = true;
            ARPlaneManager.enabled = false;
        }
    } 

}
