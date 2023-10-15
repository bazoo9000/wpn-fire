using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    static public int _nrEnemies = 0;
    public GameObject[] _enemies;
    public bool _hasSpawned = false;
    public float _timeToWait = 2f; // spawn cooldown in seconds
    private float _timer;

    private void Start()
    {
        _nrEnemies = 0;
    }

    private void Update()
    {
        if (_hasSpawned)
        {
            Wait();
        }
    }

    public void SpawnEnemy()
    {
        if (!_hasSpawned)
        {
            _hasSpawned = true;
            Instantiate(_enemies[MainMenuScripts._choice], transform.position, Quaternion.identity);
            _nrEnemies++;
            _timer = _timeToWait;
        }
    }

    private void Wait()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            _hasSpawned = false;
        }
    }
}
