using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // The background music audio clip
    private AudioSource audioSource;   // The AudioSource component

    private void Start()
    {
        // Get or add the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set up the AudioSource properties
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;  // Ensure the music loops
        audioSource.volume = 0.03f; // Adjust volume as needed
        audioSource.Play();      // Start playing the music
    }
}
