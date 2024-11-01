using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour
{
    public Button playButton;          // Reference to the UI Button
    public AudioSource audioSource;    // Reference to the AudioSource component
    public AudioClip[] audioClips;     // Array to hold your audio clips

    private int currentClipIndex = 1;  // To track which clip to play

        // Reference to your UI button
    public Button prevButton;

    // Method to be called when the previous button is clicked
    void OnButtonClick()
    {

        // Add your custom action here, e.g., load a scene, trigger animation, etc.
        Debug.Log(currentClipIndex);

        // THE ISSUE IS BECAUSE THE WELCOME IS  NOT IN ARRAY, SO INDEX 0 IS ACTUALLY INSTRUCT1 
        // SIMPLE FIX IS TO PUT WELCOME AT 0 AND START ARRAY AT 1
        currentClipIndex = currentClipIndex - 2; // its not subtracting here
        Debug.Log(currentClipIndex);
            
        StartCoroutine(PlayAudioSequence());
            
        
        

    }

    void Start()
    {
        // Add a listener to the button that will call the PlayNextAudio method when clicked
        playButton.onClick.AddListener(PlayNextAudio);

        // Ensure the button is assigned
        if (prevButton != null)
        {
            // Add a listener to the button's onClick event
            prevButton.onClick.AddListener(OnButtonClick);
        }

    }

    void PlayNextAudio()
    {
        if (currentClipIndex < audioClips.Length)
        {
            // Play the current audio clip
            StartCoroutine(PlayAudioSequence());
        }
    }

    IEnumerator PlayAudioSequence()
    {
        // Set the current audio clip to the AudioSource
        audioSource.clip = audioClips[currentClipIndex];
        audioSource.Play();

        // Move to the next clip in the array
        currentClipIndex++;

        // Wait for the current clip to finish playing
        yield return new WaitForSeconds(audioSource.clip.length);

        

    
        // Optional: Loop the audio back to the first clip after the last one plays
        if (currentClipIndex > audioClips.Length)
        {
            currentClipIndex = 0;
        }
    }
}
