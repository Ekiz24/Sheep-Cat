using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoudnessScaler : MonoBehaviour
{
    public AudioSource source;

    public Vector3 minScale;
    public Vector3 maxScale;

    public AudioDetector detector;

    public float loudnessSensibility=100f;
    public float threshold = 0.1f;
    public float smoothSpeed = 1f;

    private Vector3 currentScale;

    // Start is called before the first frame update
    void Start()
    {
        currentScale = minScale;
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetVolume(source)*loudnessSensibility;

        if(loudness<threshold)
        {
            loudness = 0;
        }

        //transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
        Vector3 targetScale = Vector3.Lerp(minScale, maxScale, loudness);
        currentScale = Vector3.Lerp(currentScale, targetScale, smoothSpeed * Time.deltaTime);
        transform.localScale = currentScale;
    }
}
