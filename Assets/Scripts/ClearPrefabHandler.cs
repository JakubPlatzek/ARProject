using UnityEngine;

public class ClearPrefabHandler : MonoBehaviour
{
    public PlaceObject placeObject;

    public void RemoveLayout(){
        Destroy(placeObject.placedLayout);
        gameObject.SetActive(false);
        
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("popUP");
        foreach (var obj in objectsWithTag)
        {
            Destroy(obj);
        }
        
    }
}
