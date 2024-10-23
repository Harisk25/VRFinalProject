using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skip : MonoBehaviour
{

    // Reference to your UI button
    public Button myButton;
    // Reference to the player's Transform
    public Transform playerTransform;

    // The position you want to teleport the player to
    public Vector3 teleportPosition;

    void Start()
    {
        // Ensure the button is assigned
        if (myButton != null)
        {
            // Add a listener to the button's onClick event
            myButton.onClick.AddListener(OnButtonClick);
        }
    }

    // Method to be called when the button is clicked
    void OnButtonClick()
    {
        // Add your custom action here, e.g., load a scene, trigger animation, etc.
        //Debug.Log("Button clicked! Teleporting player...");
        playerTransform.position = teleportPosition;

    }

    void OnDestroy()
    {
        // Clean up the listener when this object is destroyed
        if (myButton != null)
        {
            myButton.onClick.RemoveListener(OnButtonClick);
        }
    }
}
