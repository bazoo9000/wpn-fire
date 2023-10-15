using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float _damage = 10f;
    public bool _wasHit = false;
    public AudioClip[] _hitSFX;
    private Animator _anim;
    private float _timer;

    private void Awake()
    {
        _anim = GetComponentInParent<Animator>();
        _timer = _anim.GetCurrentAnimatorStateInfo(0).length;
    }

    private void Start()
    {
        _damage += (_damage * RoundSystem._procent) * (RoundSystem._round - 1);
    }

    private void Update()
    {
        if (_wasHit)
        {
            Timer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.transform.GetComponent<Player>();
        if (player != null && !_wasHit)
        {
            player.TakeDamage(_damage);
            AudioSource s = GetComponent<AudioSource>();
            s.clip = _hitSFX[Random.Range(0, _hitSFX.Length)];
            s.Play();
            _wasHit = true;
            _timer = _anim.GetCurrentAnimatorStateInfo(0).length - 0.1f;
        }
    }

    public void Timer()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _wasHit = false;
        }
    }
}
