using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ExitManualModeHandler : MonoBehaviour
{
    public GameObject FreePlacementMode;
    public GameObject ManualMode;
    public GameObject clearButton;
    public ARPointCloudManager ARPointCloudManager;
    public ARPlaneManager ARPlaneManager;
    public ManualPlacement manualPlacement;
    public GameObject MainMenuButton;
    public List<HandleMenu> ObjectsToUpdate;


    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton.SetActive(false);
    }

    public void ExitManualMode(){
        if(FreePlacementMode.GetComponent<FreeHandPlacement>().quest != null || manualPlacement.quest != null){
            clearButton.SetActive(true);
        }
        else{
            clearButton.SetActive(false);
        }
        FreePlacementMode.SetActive(false);
        ManualMode.SetActive(false);
        MainMenuButton.SetActive(true);
        foreach (var item in ObjectsToUpdate)
        {
            item.isMenuOpen = false;
        }
        ARPointCloudManager.enabled = false;
        foreach (var item in ARPointCloudManager.trackables)
        {
            item.gameObject.SetActive(false);
        }
        ARPlaneManager.enabled = false;
        foreach (var item in ARPlaneManager.trackables)
        {
            item.gameObject.SetActive(false);
        }
        if (manualPlacement)
        {
            manualPlacement.tableCorners = new List<Vector3>();   
        }
    }
}
