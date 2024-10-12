using UnityEngine;

public class catSFX : MonoBehaviour
{
    public AudioClip catSound; // Assign this sound in the inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Play the cat sound at the position of the GameObject this script is attached to
            // Here, the clip should be edited externally to be a non-spatial (stereo) sound
            AudioSource.PlayClipAtPoint(catSound, Camera.main.transform.position);  // Plays at the camera position to centralize the sound effect
        }
    }
}