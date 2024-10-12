using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchMover : MonoBehaviour
{
    public AudioSource audioSource; // 用于获取音频输入
    public AudioDetector estimator; // 用于音调估计
    public float moveSpeed = 0.1f; // 移动速度
    private Rigidbody2D rb; // 用于2D物理控制

    void Start()
    {
        // 获取 Rigidbody2D 组件
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 获取当前的频率估计
        var frequency = estimator.Estimate(audioSource);

        if (!float.IsNaN(frequency))
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
            case "E":
                moveDirection = Vector2.left; // 向左移动
                break;
            case "G":
                moveDirection = Vector2.right; // 向右移动
                break;
            case "B":
                moveDirection = Vector2.up; // 向上移动
                break;
        }

        // 使用 Rigidbody2D 移动物体
        rb.MovePosition(rb.position + moveDirection * moveSpeed);
    }
}
