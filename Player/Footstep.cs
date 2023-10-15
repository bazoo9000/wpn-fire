using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    private AudioSource _audio;
    [SerializeField] private AudioClip[] _footstep;
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void Step()
    {
        _audio.clip = _footstep[Random.Range(0, _footstep.Length)];
        _audio.Play();
    }
}
