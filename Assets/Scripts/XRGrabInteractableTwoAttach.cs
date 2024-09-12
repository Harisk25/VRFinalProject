using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;



public class XRGrabInteractableTwoAttached : XRGrabInteractable

{
    public Transform leftAttachedTransform;
    public Transform rightAttachedTransform;

    protected override void OnSelectEntering(SelectEnterEventArgs args)

    {
        if (args.interactorObject.transform.CompareTag("Left Hand"))
        {
            attachTransform = leftAttachedTransform;
        }
        else if (args.interactorObject.transform.CompareTag("Right Hand"))
        {
            attachTransform = rightAttachedTransform;
        }
        base.OnSelectEntering(args);
    }

}
