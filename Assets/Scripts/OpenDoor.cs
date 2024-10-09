using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject target;
    public GameObject door;

    // Update is called once per frame
    void Update()
    {
        if (target.transform.GetComponent<Renderer>().material.color.Equals(Color.green))
        {
            if (door != null)
            {
                Destroy(door);
            }
        }
    }
}
