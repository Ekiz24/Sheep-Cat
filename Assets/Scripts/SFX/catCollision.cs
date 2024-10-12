using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catCollision : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the object
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("Missing AudioSource component");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if this object has the tag "cat" and if the colliding object has the tag "wall"
        if (gameObject.CompareTag("Cat") || collision.collider.CompareTag("Wall"))
        {
            // Play the collision sound
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else
            {
                Debug.Log("AudioSource is missing or already playing");
            }
        }
    }
}