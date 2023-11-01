using UnityEngine;

public class FaceCamera : MonoBehaviour
{

    private Transform mainCameraTransform;

    private void Start()
    {
        // Find the main camera in the scene
        mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        // Rotate the prefab to face the camera
        transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward, mainCameraTransform.rotation * Vector3.up);
    }
}