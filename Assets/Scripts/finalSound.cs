using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalSound : MonoBehaviour
{
    public GameObject target;

    public AudioClip doorOpenSound; // Assign the sound effect in the Inspector

    private AudioSource audioSource;

    private int playOnce = 0;

    void Start()
    {
        // Get the AudioSource component from the target (this object)
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = doorOpenSound;
    }

    // Update is called once per frame
    // AUDIO ISSUES MAY BE HERE
    void Update()
    {
        if (target.transform.GetComponent<Renderer>().material.color.Equals(Color.green))
        {

            if (playOnce == 0)
            {
                playSound();
            }

        }
    }

    public void playSound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        playOnce = 1;
        
    }
}
