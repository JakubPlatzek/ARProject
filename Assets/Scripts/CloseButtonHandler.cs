using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButtonHandler : MonoBehaviour
{
    public GameObject ObjectToClose;
    public HandleMenu ObjectToUpdate;
    public void CloseMenu(){
        ObjectToClose.SetActive(false);
        ObjectToUpdate.isMenuOpen = false;
    }
}
