using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _maxHp = 0f;
    public float _hp;
    private Animator _anim;
    [SerializeField] private EnemyHealthBar _hpBar;
    [SerializeField] private AudioClip[] _pain;
    [SerializeField] private AudioClip[] _death;
    [SerializeField] private AudioSource _audioSource;
    private bool _hasEnded = false;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        float w = transform.localScale.x + (transform.localScale.x / 25) * (RoundSystem._round);
        float h = transform.localScale.y + (transform.localScale.y / 25) * (RoundSystem._round);
        transform.localScale = new Vector3(w, h, 1f);
    }

    private void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        _hp = _maxHp + (_maxHp * RoundSystem._procent) * (RoundSystem._round - 1);
        Debug.Log(_maxHp * RoundSystem._procent);
        _hpBar.SetMaxHP(_hp);
    }

    private void Update()
    {
        if (GameOver._isOver && !_hasEnded)
        {
            Destroy(_hpBar.gameObject);
            _hasEnded = true;
        }
    }

    bool bullshit = false;
    public void TakeDamage(float damage)
    {
        _hp -= damage;
        _hpBar.SetHP(_hp);
        if (_hp <= 0f)
        {
            if (!bullshit)
            {
                bullshit = true;
                Spawner._nrEnemies--;
            }
            Destroy(_hpBar.gameObject);
            _anim.SetBool("isAlive", false);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            int index1 = Random.Range(0, _death.Length);
            _audioSource.clip = _death[index1];
            _audioSource.Play();
            Destroy(gameObject, 2f);
        }
        else
        {
            int index = Random.Range(0, _pain.Length);
            _audioSource.clip = _pain[index];
            _audioSource.Play();
        }
    }
}
