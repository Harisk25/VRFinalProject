using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject target;
    public GameObject door;
    public AudioClip doorOpenSound; // Assign the sound effect in the Inspector

    private AudioSource audioSource;

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
            if (door != null)
            {
                // Play the sound effect before destroying the door
                if (audioSource != null && doorOpenSound != null)
                {
                    audioSource.Play();
                }
                
                // Use a coroutine to delay the destruction until the sound finishes playing
                StartCoroutine(DestroyDoorAfterSound());
            }
        }
    }

    private IEnumerator DestroyDoorAfterSound()
    {
        if (audioSource != null)
        {
            yield return new WaitForSeconds(audioSource.clip.length);
        }
        Destroy(door);
    }
}
