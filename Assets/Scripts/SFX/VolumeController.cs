using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioSource backgroundMusicSource;

    public AudioSource[] soundEffectSource;

    public Slider backgroundMusicSlider;

    public Slider soundEffectSlider;

    void Start()
    {
        backgroundMusicSlider.value = backgroundMusicSource.volume;
        soundEffectSlider.value = soundEffectSource[soundEffectSource.Length].volume;

        backgroundMusicSlider.onValueChanged.AddListener(SetBackgroundMusicVolume);
        soundEffectSlider.onValueChanged.AddListener(SetSoundEffectVolume);
    }

    public void SetBackgroundMusicVolume(float volume)
    {
        backgroundMusicSource.volume = volume;
    }

    public void SetSoundEffectVolume(float volume)
    {
        soundEffectSource[soundEffectSource.Length].volume = volume;
    }
}
