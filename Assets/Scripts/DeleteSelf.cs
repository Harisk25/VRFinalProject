using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSelf : MonoBehaviour
{
    public ShowMessageFromList UiIndex; // index = the current message being displayed
    public int targetIndex; // the index number we want our image to appear
    public GameObject thisObject;

    // Update is called once per frame
    void Update()
    {
        if (UiIndex.index >= targetIndex)
        {
            thisObject.SetActive(false);
        }
    }
}
