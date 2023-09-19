using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectQuestHandler : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

    void Awake(){
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
    }

    public void Evaluate(){
        Debug.Log("Selected: " + dropdown.options[dropdown.value].text);
    }
}
