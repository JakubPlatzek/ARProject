using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCharacterSheet : MonoBehaviour
{

    public GameObject characterSheet;

    public void RemoveCharacterSheetFromScene()
    {
        characterSheet.SetActive(false);
    }
}
