using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPlay : MonoBehaviour
{
    public AudioSource trigSource;
    public AudioClip[] soundList;
    public AudioClip sound;
    public int count = 0;

    void OnTriggerEnter() 
    {
        trigSource.PlayOneShot(soundList[count]);
        count++;

    }
}
