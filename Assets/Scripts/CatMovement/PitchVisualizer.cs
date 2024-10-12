using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchVisualizer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioDetector estimator;
    public TextMesh textFrequency;
    public Transform Indicator;

    public float loudnessThreshold = 0.5f;
    public float loudnessSensibility = 100f;
    public float estimateRate = 8;
    public float lastFrequency;
    public float smoothRotationSpeed = 5f;

    private int minFrequency;
    private int maxFrequency;

    void Start()
    {
        InvokeRepeating(nameof(UpdateVisualizer), 0, 1.0f / estimateRate);
        minFrequency = estimator.frequencyMin;
        maxFrequency = estimator.frequencyMax;
    }

    private void Update()
    {
        
    }

    void UpdateVisualizer()
    {
        var frequency = estimator.Estimate(audioSource);

        var srh = estimator.SRH;
        var numPoints = srh.Count;
        var positions = new Vector3[numPoints];
        for (int i = 0; i < numPoints; i++)
        {
            var position = (float)i / numPoints - 0.5f;
            var value = srh[i] * 0.005f;
            positions[i].Set(position, value, 0);
        }

            textFrequency.text = string.Format("{0}\n{1:0.0} Hz", GetNameFromFrequency(frequency), lastFrequency);

        //UpdateIndicatorRotation(frequency);
    }

    string GetNameFromFrequency(float frequency)
    {
        float loudness = estimator.GetVolume(audioSource) * loudnessSensibility;

        if (loudness > loudnessThreshold)
        {
            var noteNumber = Mathf.RoundToInt(12 * Mathf.Log(frequency / 440) / Mathf.Log(2) + 69);
            string[] names = {
            "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"};
            lastFrequency = frequency;
            return names[noteNumber % 12];
        }
        else
        {
            var noteNumber = Mathf.RoundToInt(12 * Mathf.Log(lastFrequency / 440) / Mathf.Log(2) + 69);
            string[] names = {
            "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"};
            return names[noteNumber % 12];
        }
    }

    //void UpdateIndicatorRotation(float frequency)
    //{
    //    lastFrequency = frequency;
    //    float loudness = estimator.GetVolume(audioSource) * loudnessSensibility;

    //    if (loudness > loudnessThreshold)
    //    {
    //        // 将频率限制在最小和最大范围内
    //        frequency = Mathf.Clamp(frequency, minFrequency, maxFrequency);

    //        // 将频率映射到角度范围
    //        float targetRotationZ = Mathf.Lerp(0, 360, Mathf.InverseLerp(minFrequency, maxFrequency, frequency));

    //        // 获取当前旋转角度
    //        float currentRotationZ = Indicator.rotation.eulerAngles.z;

    //        // 使用 Mathf.LerpAngle 来平滑插值 Z 轴旋转角度，使用 Time.deltaTime 控制过渡平滑
    //        float smoothRotationZ = Mathf.LerpAngle(currentRotationZ, targetRotationZ, Time.deltaTime * smoothRotationSpeed);

    //        // 设置平滑后的旋转角度
    //        Indicator.rotation = Quaternion.Euler(0, 0, smoothRotationZ);
    //    }
    //    else
    //    {
    //        lastFrequency = Mathf.Clamp(lastFrequency, minFrequency, maxFrequency);
    //        float targetRotationZ = Mathf.Lerp(0, 360, Mathf.InverseLerp(minFrequency, maxFrequency, lastFrequency));
    //        float currentRotationZ = Indicator.rotation.eulerAngles.z;
    //        float smoothRotationZ = Mathf.LerpAngle(currentRotationZ, targetRotationZ, Time.deltaTime * smoothRotationSpeed);
    //        Indicator.rotation = Quaternion.Euler(0, 0, smoothRotationZ);
    //    }
    //}
}
