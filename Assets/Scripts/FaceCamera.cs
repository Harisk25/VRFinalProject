using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FaceCamera : MonoBehaviour
{
    private Transform mainCamera;

    void Start()
    {
        // Find the main camera
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        // Make the text component face the camera
        transform.LookAt(transform.position + mainCamera.rotation * Vector3.forward,
                         mainCamera.rotation * Vector3.up);
    }
}
