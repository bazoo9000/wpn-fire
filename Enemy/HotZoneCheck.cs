using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour
{
    private EnemyBehaviour _enemyParent;
    private bool _inRange;
    private Animator _anim;

    private void Awake()
    {
        _enemyParent = GetComponentInParent<EnemyBehaviour>();
        _anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (_inRange && !_anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !PauseMenuScripts._isPaused)
        {
            _enemyParent.Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _inRange = false;
            gameObject.SetActive(false);
            _enemyParent._detectionArea.SetActive(true);
            _enemyParent._inRange = false;
            _anim.SetBool("isRunning", false);
        }
    }
}