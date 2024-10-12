using UnityEngine;
using System.Collections;

public class sheepSFX : MonoBehaviour
{
    public AudioSource audioSource;
    public float delayInSeconds = 5.0f;

    IEnumerator Start()
    {
        if (audioSource == null)
        {
            yield break;
        }

        while (true)
        {
            yield return new WaitForSeconds(delayInSeconds);
            audioSource.Play();
        }
    }
}


