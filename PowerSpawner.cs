using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
    public Transform[] _spawners;
    public GameObject[] _powers;
    private bool _hasSpawned = false;
    private int _currentRound = 1;

    private void FixedUpdate()
    {
        if (!_hasSpawned && RoundSystem._round % 4 == 0 && _currentRound == RoundSystem._round)
        {
            _hasSpawned = true;
            Debug.Log("SPAWNED!");
            int i = Random.Range(0, _spawners.Length);
            SpawnPower(_spawners[i]);
        }

        if (_currentRound != RoundSystem._round)
        {
            _currentRound = RoundSystem._round;
            _hasSpawned = false;
        }
    }

    public void SpawnPower(Transform spawner)
    {
        int i = Random.Range(0, _powers.Length);
        Instantiate(_powers[i], spawner.transform.position, Quaternion.identity);
    }
}