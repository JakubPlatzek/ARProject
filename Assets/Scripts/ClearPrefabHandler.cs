using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPrefabHandler : MonoBehaviour
{
    public PlaceObject placeObject;

    public void RemoveLayout(){
        Destroy(placeObject.placedLayout);
        gameObject.SetActive(false);
    }
}
