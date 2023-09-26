using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public ManualPlacement manualPlacement;
    public Joystick joystick; // Assume you have a Joystick component
    private GameObject movedObject;

    void Update()
    {
        // If no object to move, try getting the object from ManualPlacement.
        if (movedObject == null && manualPlacement.collectedPosition != null)
        {
            movedObject = manualPlacement.collectedPosition;
        }

        // If there is an object to move, apply joystick inputs to move it.
        if (movedObject != null)
        {
            float moveX = joystick.Horizontal;
            float moveZ = joystick.Vertical;

            Vector3 moveVector = new Vector3(moveX, 0, moveZ) * Time.deltaTime;
            movedObject.transform.Translate(moveVector);
        }
    }
}
