using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraXTracking : MonoBehaviour
{
    private Transform cameraTransform; // Reference to the XR Camera Transform


    void Start()
    {
        // Find the XR Camera using its tag (MainCamera)
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Update the object's X position based on the camera's X position
        Vector3 newPosition = transform.position;
        newPosition.x = cameraTransform.position.x;
        newPosition.z = cameraTransform.position.z;
        transform.position = newPosition;
    }
}

