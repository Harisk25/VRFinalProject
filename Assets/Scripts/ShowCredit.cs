using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCredit : MonoBehaviour
{
    public GameObject target;
    public GameObject credits;
    private bool firstTime = false; // This makes sure we only make the credits visible after the target goes green for the first time

    // Update is called once per frame
    // AUDIO ISSUES MAY BE HERE
    void Update()
    {
        if (target.transform.GetComponent<Renderer>().material.color.Equals(Color.green))
        {
         if(firstTime == false)
            {
                credits.SetActive(true);
                firstTime = true;
            }
         
        }
    }
}
