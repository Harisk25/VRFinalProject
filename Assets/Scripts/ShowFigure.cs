using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFigure : MonoBehaviour
{
    public ShowMessageFromList UiIndex; // index = the current message being displayed
    public int targetIndex; // the index number we want our image to appear
    public int targetIndexMax; // if lessThan is checked, this value will ensure our image is shown for as long as the UiIndex is less than or equal to this number
    public bool greaterThan; // if true, this will make sure the image stays visable for as long as the index is greater than the target index
    public bool lessThan; // if true, it will ensure our image is shown for as long as the UiIndex is less than or equal to targetIndexMax
    public GameObject thisObject; // The object/image to be shown

    // Update is called once per frame
    void Update()
    {
        if(greaterThan == true)
        {
            if (lessThan == true)
            {
                if (targetIndex <= UiIndex.index && targetIndexMax >= UiIndex.index)
                {
                    thisObject.SetActive(true);
                }
                else
                {
                    thisObject.SetActive(false);
                }
            }
            else
            {
                if (targetIndex <= UiIndex.index)
                {
                    thisObject.SetActive(true);
                }
                else
                {
                    thisObject.SetActive(false);
                }
            }
        }
        else
        {
            if (UiIndex.index == targetIndex)
            {
                thisObject.SetActive(true);
            }
            else
            {
                thisObject.SetActive(false);
            }
        }
    }
}
