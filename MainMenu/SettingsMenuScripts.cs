using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenuScripts : MonoBehaviour
{
    [SerializeField] private AudioSource _press;
    [SerializeField] private AudioMixer _sfx;
    [SerializeField] private AudioMixer _music;

    public void SetVolumeSFX(float volume)
    {
        _sfx.SetFloat("volumeSFX", volume);
        PlayerPrefs.SetFloat("volumeSFX", volume);
    }

    public void SetVolumeMusic(float volume)
    {
        _music.SetFloat("volumeMusic", volume);
        PlayerPrefs.SetFloat("volumeMusic", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        _press.Play();
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetString("isFullscreen", isFullscreen.ToString());
    }
}