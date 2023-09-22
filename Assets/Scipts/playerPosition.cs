using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraXTracking : MonoBehaviour
{
    public Transform cameraTransform; // Reference to the XR Camera Transform
    public Transform playerTransform;

    void Start()
    {
    }

    void Update()
    {
        // Update the object's X position based on the camera's X position
        Vector3 newPosition = playerTransform.position;
        newPosition.x = cameraTransform.position.x;
        // newPosition.z = cameraTransform.position.z;
        playerTransform.position = newPosition;

        Vector3 newCameraPosition = cameraTransform.position;
        newCameraPosition.y = playerTransform.position.y;
        newCameraPosition.z = playerTransform.position.z;
        cameraTransform.position = newCameraPosition;
    }
}

