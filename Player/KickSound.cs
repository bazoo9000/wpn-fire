using UnityEngine;

public class KickSound : MonoBehaviour
{
    private AudioSource _audio;
    [SerializeField] private AudioClip[] _clips;
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void Kick()
    {
        _audio.clip = _clips[Random.Range(0, _clips.Length)];
        _audio.Play();
    }
}