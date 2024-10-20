using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class JoystickHeight : MonoBehaviour
{
    public Transform cameraTransform; // Assign the Camera's transform
    public float heightMultiplier = 1.0f; // Sensitivity or speed of height adjustment

    // This method will be called when SendMessage is invoked
    public void AdjustCameraOffset(float joystickYValue)
    {
        Vector3 newPosition = cameraTransform.position;
        newPosition.y += joystickYValue * heightMultiplier * Time.deltaTime;
        cameraTransform.position = newPosition;
    }
}
