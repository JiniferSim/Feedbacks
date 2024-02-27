using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardText : MonoBehaviour
{
    private Camera mainCamera;
    private Transform cameraTransform;
    private Transform textTransform;

    void Start()
    {
        // Get references to the main camera and text mesh transform
        mainCamera = Camera.main;
        cameraTransform = mainCamera.transform;
        textTransform = transform;
    }

    void Update()
    {
        // Ensure the text always faces the camera
        textTransform.LookAt(textTransform.position + cameraTransform.rotation * Vector3.forward, cameraTransform.rotation * Vector3.up);
    }
}
