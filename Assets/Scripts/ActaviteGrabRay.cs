using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActaviteGrabRay : MonoBehaviour
{
    public GameObject leftGrabRay;
    public GameObject rightGrabRay;

    public XRDirectInteractor leftDirectionGrab;
    public XRDirectInteractor rightDirectionGrab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftGrabRay.SetActive(leftDirectionGrab.interactablesSelected.Count == 0);
        rightGrabRay.SetActive(rightDirectionGrab.interactablesSelected.Count == 0);
    }
}
