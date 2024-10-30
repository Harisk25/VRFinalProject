using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustHeightSlider : MonoBehaviour
{
    public Transform playerHeight;
    public float YHeight = 0;

    // Update is called once per frame
    void Update()
    {
        playerHeight.position = new Vector3(playerHeight.position.x , YHeight, playerHeight.position.z);

    }

    public void AdjustHeight(float newYHeight)
    {
        YHeight = newYHeight;
    }
}
