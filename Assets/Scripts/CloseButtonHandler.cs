using System.Collections.Generic;
using UnityEngine;

public class CloseButtonHandler : MonoBehaviour
{
    public GameObject ObjectToClose;
    public List<HandleMenu> ObjectsToUpdate;
    public void CloseMenu(){
        ObjectToClose.SetActive(false);
        foreach (var item in ObjectsToUpdate)
        {
            item.isMenuOpen = false;
        }
    }
}
