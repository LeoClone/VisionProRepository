using UnityEngine;

public class ButtonAudioPlayer : MonoBehaviour
{
    private AudioSource audioSource; // AudioSource component to play the sound

    void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // Public method to play the sound, which can be called on button click
    public void PlaySound()
    {
        if (audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
