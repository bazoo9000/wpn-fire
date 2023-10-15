using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    #region PUBLIC variables
    public float _attackDistance; // distanta minima de atac
    public float _moveSpeed;
    public float _timer; // pt cooldown intre atacuri
    [HideInInspector] public Transform _target;
    [HideInInspector] public bool _inRange;
    public GameObject _hotZone;
    public GameObject _detectionArea;
    #endregion
    #region PRIVATE variables
    private Animator _anim;
    private float _distance; // salveaza distanta dintre player si enemy
    private bool _isAttacking;
    private bool _inCooldown; // verifica daca nu ataca la moment
    private float _intTimer;
    #endregion

    private void Awake()
    {
        _intTimer = _timer;
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        _attackDistance += (_attackDistance * RoundSystem._procent / 3) * (RoundSystem._round - 1);
    }

    private void Update()
    {
        if (_inRange && _anim.GetBool("isAlive") && !PauseMenuScripts._isPaused)
        {
            EnemyLogic();
        }
    }

    #region ENEMY LOGIC

    void EnemyLogic()
    {
        _distance = Vector2.Distance(transform.position, _target.position);

        if (_distance > _attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (_distance <= _attackDistance && _inCooldown == false)
        {
            Attack();
        }

        if (_inCooldown)
        {
            Cooldown();
            _anim.SetBool("isAttacking", false);
        }
    }

    #region FUNCTII PENTRU EnemyLogic()

    void Cooldown()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0 && _inCooldown && _isAttacking)
        {
            _inCooldown = false;
            _timer = _intTimer;
        }
    }

    void Move()
    {
        _anim.SetBool("isRunning", true);
        if (!_anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Vector2 targetPosition = new Vector2(_target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, _moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        _timer = _intTimer;
        _isAttacking = true;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, rb.velocity.y);

        _anim.SetBool("isRunning", false);
        _anim.SetBool("isAttacking", true);
    }

    void StopAttack()
    {
        _inCooldown = false;
        _isAttacking = false;
        _anim.SetBool("isAttacking", false);
    }

    #endregion

    #endregion

    public void Flip() // asta ii folosit in alt script
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x < _target.position.x && _anim.GetBool("isAlive"))
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
    }

    /*
    asta o bagam in Attack.anim
    este un eveniment si o sa bage atacul in CD ca sa nu mai punem noi din script :)
    */
    public void TriggerCooldown()
    {
        _inCooldown = true;
    }
}
