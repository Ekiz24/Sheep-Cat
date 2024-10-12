using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class PitchMover : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioDetector estimator;
    public float moveSpeed = 0.1f;
    public float loudnessSensibility = 100f;
    public float loudnessThreshold = 0.5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var frequency = estimator.Estimate(audioSource);
        float loudness = estimator.GetVolume(audioSource) * loudnessSensibility;

        if (!float.IsNaN(frequency)&&loudness>loudnessThreshold)
        {
            // 获取音符名称
            string note = GetNameFromFrequency(frequency);

            // 根据音符名称移动物体
            MoveObject(note);
        }
    }

    string GetNameFromFrequency(float frequency)
    {
        var noteNumber = Mathf.RoundToInt(12 * Mathf.Log(frequency / 440) / Mathf.Log(2) + 69);
        string[] names = {
            "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"
        };
        return names[noteNumber % 12];
    }

    void MoveObject(string note)
    {
        Vector2 moveDirection = Vector2.zero; // 使用 Vector2 进行 2D 移动

        switch (note)
        {
            case "C":
                moveDirection = Vector2.down; // 向下移动
                break;
            case "D":
                moveDirection = Vector2.left; // 向左移动
                break;
            case "E":
                moveDirection = Vector2.right; // 向右移动
                break;
            case "F":
                moveDirection = Vector2.up; // 向上移动
                break;
        }

        // 使用 Rigidbody2D 移动物体
        rb.MovePosition(rb.position + moveDirection * moveSpeed);
    }
}
