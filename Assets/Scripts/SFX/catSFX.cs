using UnityEngine;

public class catSFX : MonoBehaviour
{
    public AudioSource audioSource;

    void Update()
    {  
        if (Input.GetKeyDown(KeyCode.C))
        {    
            audioSource.Play();
        }
    }
}

