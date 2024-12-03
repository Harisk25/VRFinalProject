using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HeightAdjust : MonoBehaviour
{
    public Transform playerHeight;
    public Slider slider;
    public InputActionProperty rightControllerJoyStick;


    // Update is called once per frame
    void Update()
    {
        if (rightControllerJoyStick.action.ReadValue<Vector2>().y <= -0.8 || rightControllerJoyStick.action.ReadValue<Vector2>().y >= 0.8)
        {
            if (rightControllerJoyStick.action.ReadValue<Vector2>().y <= -0.8 && playerHeight.position.y >= 0.75)
            {   
                playerHeight.position += new Vector3(0, ((float)0.01) * -1, 0);
            }else if (rightControllerJoyStick.action.ReadValue<Vector2>().y >= 0.8 && playerHeight.position.y <= 1.5)
            {
                playerHeight.position += new Vector3(0, ((float)0.01), 0);
            }
            slider.value = playerHeight.position.y; // update display value
        }
    }
}
