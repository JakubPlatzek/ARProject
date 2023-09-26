using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectQuestHandler : MonoBehaviour
{
    public PlaceObject placeObject;
    public TMP_Dropdown dropdown;
    public GameObject questMenu;
    public GameObject mainMenu;
    public GameObject placementMenu;
    public List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

    void Awake(){
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
    }

    public void Evaluate(){
        placeObject.objectToPlace = dropdown.options[dropdown.value].text;
        mainMenu.SetActive(false);
        questMenu.SetActive(false);
        placementMenu.SetActive(true);
    }
}
