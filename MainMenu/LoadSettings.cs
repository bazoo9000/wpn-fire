using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class LoadSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _sfx;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private AudioMixer _music;
    [SerializeField] private Slider _musicSlider;

    void Start()
    {
        _sfx.SetFloat("volumeSFX", PlayerPrefs.GetFloat("volumeSFX"));
        _music.SetFloat("volumeMusic", PlayerPrefs.GetFloat("volumeMusic"));
        _sfxSlider.value = PlayerPrefs.GetFloat("volumeSFX");
        _musicSlider.value = PlayerPrefs.GetFloat("volumeMusic");
    }
}
