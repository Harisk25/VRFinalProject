using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public ShowMessageFromList UiIndex; // index = the current message being displayed
    public int targetIndex; // the index number we want our image to appear
    public TextMeshProUGUI thisObject; // The object/image to be shown

    // Update is called once per frame
    void Update()
    {
        if(targetIndex == UiIndex.index)
        {
            thisObject.text = "Next";
        }
    }
}
