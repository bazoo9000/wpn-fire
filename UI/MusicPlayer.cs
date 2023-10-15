using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _playlist;
    [SerializeField] private AudioLowPassFilter _filter;
    private int id;

    private void Start()
    {
        _filter.cutoffFrequency = 22000f;
        Random.InitState((int)System.DateTime.Now.Ticks);
        AudioSource music = GetComponent<AudioSource>();
        id = Random.Range(0, _playlist.Length);
        music.clip = _playlist[id];
        music.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeMusic();
        }

        if (PauseMenuScripts._isPaused)
        {
            _filter.cutoffFrequency = 1000f;
        }
        else
        {
            _filter.cutoffFrequency = 22000f;
        }
    }

    public void ChangeMusic()
    {
        AudioSource music = GetComponent<AudioSource>();
        id++;
        music.clip = _playlist[id % _playlist.Length];
        music.Play();
    }
}