using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundSystem : MonoBehaviour
{
    static public int _round;
    static public float _procent = 10f / 100f; // care este procentul pentru scaling, default = 10%
    [SerializeField] private Text _counter;
    [SerializeField] private CanvasGroup _appear;
    [SerializeField] private Animation _anim;
    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private int a = 4; // prin desmos am aflat :)
    private bool _hasEnded = false;
    private bool _hasSpawnedAll = false;
    private int _nrEnemiesToSpawn = 1;
    private int _spawnedEnemies = 0; // pentru cand spawnez daca am spawnat exact cat trebuie
    private float _timeToWait = 3f;
    private float _timer;

    private void Start()
    {
        _round = 1;
        ShowText();
        _hasEnded = false;
        _hasSpawnedAll = false;
        _spawnedEnemies = 0;
    }

    private void Update()
    {
        if (!_hasSpawnedAll && !_hasEnded)
        {
            int index = Random.Range(0, _spawners.Length);

            if (!_spawners[index]._hasSpawned)
            {
                _spawners[index].SpawnEnemy();
                _spawnedEnemies++;
            }

            if (_spawnedEnemies == _nrEnemiesToSpawn)
            {
                _timer = 0f;
                _hasSpawnedAll = true;
            }
        }

        if (Spawner._nrEnemies <= 0 && !_hasEnded)
        {
            _hasEnded = true;
            _timer = _timeToWait;
        }

        if (_hasEnded)
        {
            Wait();
        }
    }

    private void FixedUpdate()
    {
        //Welcome to Debug Hell
        //Debug.Log("Has Ended? " + _hasEnded);
        //Debug.Log("Has Spawned All? " + _hasSpawnedAll);
        //Debug.Log("How many enemies left = " + Spawner._nrEnemies);
    }

    private void ShowText()
    {
        _counter.text = "Round: " + _round;
        Text black = _appear.GetComponentInChildren<Text>();
        black.text = "Round " + _round;
        _anim.Play();
    }

    private void Wait()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            _round++;
            _spawnedEnemies = 0;
            _nrEnemiesToSpawn = 1 + (_round + a) / (a + 1);
            ShowText();
            _hasEnded = false;
            _hasSpawnedAll = false;
        }
    }
}