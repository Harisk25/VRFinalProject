using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonStartRay : MonoBehaviour
{
    public LineRenderer ray;
    private bool rayActive = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ToggleRay());
    }

    public void ToggleRay()
    {
        if (rayActive == false)
        {
            rayActive = true;
            ray.enabled = true;
        }
        else if (rayActive == true)
        {
            rayActive = false;
            ray.enabled = false;

        }
    }
}
