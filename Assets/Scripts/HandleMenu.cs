using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMenu : MonoBehaviour
{
    public bool isMenuOpen = false;
    public GameObject menu;

    public void HandleButton(){
        Handle(!isMenuOpen);
    }

    public void Handle(bool status){
        menu.SetActive(status);
        isMenuOpen = status;
    }
}
