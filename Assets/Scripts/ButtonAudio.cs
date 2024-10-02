using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour
{
    public Button playButton;          // Reference to the UI Button
    public AudioSource audioSource;    // Reference to the AudioSource component
    public AudioClip[] audioClips;     // Array to hold your audio clips

    private int currentClipIndex = 0;  // To track which clip to play

    void Start()
    {
        // Add a listener to the button that will call the PlayNextAudio method when clicked
        playButton.onClick.AddListener(PlayNextAudio);
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

        // Wait for the current clip to finish playing
        yield return new WaitForSeconds(audioSource.clip.length);

        // Move to the next clip in the array
        currentClipIndex++;

        // Optional: Loop the audio back to the first clip after the last one plays
        if (currentClipIndex >= audioClips.Length)
        {
            currentClipIndex = 0;
        }
    }
}
