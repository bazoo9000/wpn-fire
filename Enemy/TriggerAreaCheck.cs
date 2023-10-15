using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaCheck : MonoBehaviour
{
    private EnemyBehaviour _enemyParent;

    private void Awake()
    {
        _enemyParent = GetComponentInParent<EnemyBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            _enemyParent._target = other.transform;
            _enemyParent._inRange = true;
            _enemyParent._hotZone.SetActive(true);
        }
    }
}